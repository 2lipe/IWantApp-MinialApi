using FluentValidation;
using IWantApp.Domain.Products;
using IWantApp.Dtos.Category;
using IWantApp.Extensions;
using IWantApp.Infrastructure.Repositories.CategoryRepository;

namespace IWantApp.Endpoints.Categories;

public class CreateCategory : ApiBase
{
    public static string Template => "v1/categories";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IValidator<CreateCategoryDto> validator, CreateCategoryDto data, ICategoryRepository categoryRepository)
    {
        var validationResult = await validator.ValidateAsync(data);

        if (!validationResult.IsValid)
            return ResultError(validationResult.GetErrors());

        var category = new Category
        {
            Name = data.Name,
            CreatedBy = Guid.NewGuid()
        };

        await categoryRepository.AddAsync(category);

        return CreatedOk($"v1/categories/{category.Id}", category);
    }
}