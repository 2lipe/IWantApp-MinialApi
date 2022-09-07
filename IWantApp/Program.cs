using FluentValidation;
using IWantApp.Dtos.Category;
using IWantApp.Dtos.Employee;
using IWantApp.Endpoints.Categories;
using IWantApp.Endpoints.Employees;
using IWantApp.Infrastructure.Data;
using IWantApp.Infrastructure.Repositories;
using IWantApp.Infrastructure.Repositories.CategoryRepository;
using IWantApp.Infrastructure.Repositories.EmployeeRepository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

ConfigureRepositories(builder);
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
    builder.Services.AddSqlServer<ApplicationContext>(connectionString);
    builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireUppercase = false;
        })
        .AddEntityFrameworkStores<ApplicationContext>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryDto>(lifetime: ServiceLifetime.Scoped);
    builder.Services.AddValidatorsFromAssemblyContaining<UpdateCategoryDto>(lifetime: ServiceLifetime.Scoped);

    builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeDto>(lifetime: ServiceLifetime.Scoped);
}

void ConfigureRepositories(WebApplicationBuilder builder)
{
    builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
    builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
}

void ConfigureMethods(WebApplication app)
{
    #region Category
    app.MapMethods(CreateCategory.Template, CreateCategory.Methods, CreateCategory.Handle);
    app.MapMethods(GetCategories.Template, GetCategories.Methods, GetCategories.Handle);
    app.MapMethods(UpdateCategory.Template, UpdateCategory.Methods, UpdateCategory.Handle);
    app.MapMethods(GetCategoryById.Template, GetCategoryById.Methods, GetCategoryById.Handle);
    #endregion

    #region Employee
    app.MapMethods(CreateEmployee.Template, CreateEmployee.Methods, CreateEmployee.Handle);
    app.MapMethods(GetEmployees.Template, GetEmployees.Methods, GetEmployees.Handle);

    #endregion
}