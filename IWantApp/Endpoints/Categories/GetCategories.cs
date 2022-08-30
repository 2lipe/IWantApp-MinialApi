using IWantApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationContext = IWantApp.Infrastructure.Data.ApplicationContext;

namespace IWantApp.Endpoints.Categories;

public class GetCategories
{
    public static string Template => "v1/categories";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ApplicationContext context, [FromQuery] int page = 0, [FromQuery] int pageSize = 25)
    {
        if (pageSize > 1000)
            pageSize = 1000;

        var categories = await context.Categories
            .AsNoTracking()
            .Select(x => new GetCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                HasActive = x.HasActive
            })
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var total = await context.Categories.CountAsync();

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