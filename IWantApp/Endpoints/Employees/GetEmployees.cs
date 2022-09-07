using IWantApp.Infrastructure.Repositories.EmployeeRepository;
using IWantApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints.Employees;

public class GetEmployees
{
    public static string Template => "v1/employees";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IIdentityRepository identityRepository, int page = 0, int pageSize = 25)
    {
        if (pageSize > 25)
            pageSize = 25;

        var result = await identityRepository.GetAllEmployeesWithClaimsAsync(page, pageSize);

        return Results.Ok(new ResultViewModel<IEnumerable<IdentityUser>>(result));
    }
}