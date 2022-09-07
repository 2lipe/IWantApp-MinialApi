using IWantApp.Infrastructure.Repositories.CategoryRepository;
using IWantApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class GetCategories
{
    public static string Template => "v1/categories";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ICategoryRepository categoryRepository, [FromQuery] int page = 0, [FromQuery] int pageSize = 25)
    {
        if (pageSize > 1000)
            pageSize = 1000;

        var categories = await categoryRepository.GetAllAsync(page, pageSize);

        var total = await categoryRepository.CountAsync();

        var result = new
        {
            page,
            pageSize,
            total,
            categories,
        };

        return Results.Ok(new ResultViewModel<dynamic>(result));
    }
}