using System.Security.Claims;
using FluentValidation;
using IWantApp.Dtos.Employee;
using IWantApp.Extensions;
using IWantApp.Infrastructure.Repositories.EmployeeRepository;
using IWantApp.Utils;
using IWantApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints.Employees;

public class CreateEmployee
{
    public static string Template => "v1/employees";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IValidator<CreateEmployeeDto> validator, CreateEmployeeDto data, IIdentityRepository identityRepository)
    {
        var validationResult = await validator.ValidateAsync(data);

        if (!validationResult.IsValid)
            return Results.BadRequest(new ResultViewModel<string>(validationResult.GetErrors()));

        var user = new IdentityUser
        {
            UserName = data.Email.TransformEmailInUserName(),
            Email = data.Email,
        };

        var result = await identityRepository.AddEmployeeAsync(user, data.Password);

        if (!result.Succeeded)
            return Results.BadRequest(new ResultViewModel<string>(result.GetIdentityErrors()));

        var userClaims = new List<Claim>
        {
            new("EmployeeCode", data.EmployeeCode),
            new("Name", data.Name)
        };

        var claimResult = await identityRepository.AddClaimsAsync(user, userClaims);

        if (!claimResult.Succeeded)
            return Results.BadRequest(new ResultViewModel<string>(claimResult.GetIdentityErrors()));

        return Results.Created($"/employees/{user.Id}", new ResultViewModel<IdentityUser>(user));
    }
}