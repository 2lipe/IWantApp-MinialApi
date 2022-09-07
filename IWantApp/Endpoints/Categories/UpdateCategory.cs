using FluentValidation;
using IWantApp.Domain.Products;
using IWantApp.Dtos.Category;
using IWantApp.Extensions;
using IWantApp.Infrastructure.Repositories.CategoryRepository;
using IWantApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public class UpdateCategory : ApiBase
{
    public static string Template => "v1/categories/{id:guid}";
    public static string[] Methods => new[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IValidator<UpdateCategoryDto> validator, ICategoryRepository categoryRepository, [FromRoute] Guid id, UpdateCategoryDto data)
    {
        var validationResult = await validator.ValidateAsync(data);

        if (!validationResult.IsValid)
            return ResultError(validationResult.GetErrors());

        var result = await categoryRepository.GetByIdAsync(id);

        if (result == null)
            return Results.NotFound(new ResultViewModel<Category>("Category has not found"));

        result.Name = data.Name;
        result.HasActive = data.HasActive;
        result.UpdatedAt = DateTime.UtcNow;
        result.UpdatedBy = Guid.NewGuid();

        await categoryRepository.UpdateAsync(result);

        return ResultOk("Update with success");
    }
}