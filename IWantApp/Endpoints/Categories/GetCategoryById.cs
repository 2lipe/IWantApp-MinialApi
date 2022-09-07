using IWantApp.Domain.Products;
using IWantApp.Infrastructure.Repositories.CategoryRepository;
using IWantApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class GetCategoryById
{
    public static string Template => "v1/categories/{id:guid}";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ICategoryRepository categoryRepository, [FromRoute] Guid id)
    {
        var result = await categoryRepository.GetByIdAsync(id);

        if (result == null)
            return Results.NotFound(new ResultViewModel<string>("Category has not found"));

        return Results.Ok(new ResultViewModel<Category>(result));
    }
}