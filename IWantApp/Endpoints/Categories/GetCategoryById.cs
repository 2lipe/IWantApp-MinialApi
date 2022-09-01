using IWantApp.Infrastructure.Data;
using IWantApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Endpoints.Categories;

public class GetCategoryById
{
    public static string Template => "v1/categories/{id:guid}";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ApplicationContext context, [FromRoute] Guid id)
    {
        var result = await context.Categories
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new GetCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                HasActive = x.HasActive
            })
            .FirstOrDefaultAsync();

        if (result == null)
            return Results.NotFound(new ResultViewModel<string>("Category has not found"));

        return Results.Ok(new ResultViewModel<GetCategoryViewModel>(result));
    }
}