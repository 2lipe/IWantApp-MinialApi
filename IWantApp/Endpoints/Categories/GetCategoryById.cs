using IWantApp.Infrastructure.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class GetCategoryById : ApiBase
{
    public static string Template => "v1/categories/{id:guid}";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ICategoryRepository categoryRepository, [FromRoute] Guid id)
    {
        var result = await categoryRepository.GetByIdAsync(id);

        if (result == null)
            return ResultNotFound("Category has not found");

        return ResultOk(result);
    }
}