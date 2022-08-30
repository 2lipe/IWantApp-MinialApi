using IWantApp.Domain.Products;
using IWantApp.Dtos.Category;
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

    public static async Task<IResult> Action([FromRoute] Guid id, UpdateCategoryDto data, ApplicationContext context)
    {
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