using FluentValidation;
using IWantApp.Domain.Products;
using IWantApp.Dtos.Category;
using IWantApp.Extensions;
using IWantApp.ViewModels;
using ApplicationContext = IWantApp.Infrastructure.Data.ApplicationContext;

namespace IWantApp.Endpoints.Categories;

public class CreateCategory
{
    public static string Template => "v1/categories";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IValidator<CreateCategoryDto> validator, CreateCategoryDto data, ApplicationContext context)
    {
        var validationResult = await validator.ValidateAsync(data);

        if (!validationResult.IsValid)
            return Results.BadRequest(new ResultViewModel<string>(validationResult.GetErrors()));

        var category = new Category()
        {
            Name = data.Name,
            CreatedBy = Guid.NewGuid()
        };

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();

        return Results.Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
    }
}