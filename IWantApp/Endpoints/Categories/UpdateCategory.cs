using FluentValidation;
using IWantApp.Domain.Products;
using IWantApp.Dtos.Category;
using IWantApp.Extensions;
using IWantApp.Infrastructure.Data;
using IWantApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Endpoints.Categories;

public class UpdateCategory
{
    public static string Template => "v1/categories/{id}";
    public static string[] Methods => new[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IValidator<UpdateCategoryDto> validator, ApplicationContext context, [FromRoute] Guid id, UpdateCategoryDto data)
    {
        var validationResult = await validator.ValidateAsync(data);

        if (!validationResult.IsValid)
            return Results.BadRequest(new ResultViewModel<string>(validationResult.GetErrors()));

        var result = await context.Categories
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (result == null)
            return Results.NotFound(new ResultViewModel<Category>("Category has not found"));

        result.Name = data.Name;
        result.HasActive = data.HasActive;
        result.UpdatedAt = DateTime.UtcNow;
        result.UpdatedBy = Guid.NewGuid();

        context.Categories.Update(result);
        await context.SaveChangesAsync();

        return Results.Ok(new ResultViewModel<string>("Update with success", null));
    }
}