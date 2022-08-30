using IWantApp.Endpoints.Categories;
using IWantApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ConfigureMethods(app);

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

void ConfigureMethods(WebApplication app)
{
    #region Category
    app.MapMethods(CreateCategory.Template, CreateCategory.Methods, CreateCategory.Handle);
    app.MapMethods(GetCategories.Template, GetCategories.Methods, GetCategories.Handle);
    app.MapMethods(UpdateCategory.Template, UpdateCategory.Methods, UpdateCategory.Handle);
    app.MapMethods(GetCategoryById.Template, GetCategoryById.Methods, GetCategoryById.Handle);
    #endregion
}