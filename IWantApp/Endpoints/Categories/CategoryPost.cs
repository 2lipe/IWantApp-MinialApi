using IWantApp.Domain.Products;
using ApplicationContext = IWantApp.Infrastructure.Data.ApplicationContext;

namespace IWantApp.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "v1/categories";
    public static string[] Methods => new[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(CategoryRequest categoryRequest, ApplicationContext context)
    {
        var category = new Category()
        {
            Name = categoryRequest.Name,
        };

        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();

        return Results.Created($"v1/categories{category.Id}", category.Name);
    }
}