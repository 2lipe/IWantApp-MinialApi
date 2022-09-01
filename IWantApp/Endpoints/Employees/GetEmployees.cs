using Dapper;
using IWantApp.ViewModels;
using Microsoft.Data.SqlClient;

namespace IWantApp.Endpoints.Employees;

public class GetEmployees
{
    public static string Template => "v1/employees";
    public static string[] Methods => new[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IConfiguration configuration, int page = 0, int pageSize = 25)
    {
        if (pageSize > 25)
            pageSize = 25;

        var connectionString = configuration["ConnectionStrings:DefaultConnection"];

        IEnumerable<GetEmployeesViewModel> employees;

        await using (var connection = new SqlConnection(connectionString))
        {
            var query = @"SELECT
                            [AspNetUsers].[Id],
                            [AspNetUsers].[UserName],
                            [AspNetUsers].[Email],
                            [AspNetUserClaims].[ClaimValue] AS [Name]
                        FROM
                            [AspNetUsers]
                            LEFT JOIN [AspNetUserClaims] ON [AspNetUsers].[Id] = [AspNetUserClaims].[UserId]
                                AND [ClaimType] = 'Name'
                                ORDER BY [Name]
                                OFFSET (@page) * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY";

            var pagination = new { page, pageSize };

            employees = await connection.QueryAsync<GetEmployeesViewModel>(query, pagination);
        }

        return Results.Ok(new ResultViewModel<IEnumerable<GetEmployeesViewModel>>(employees));
    }
}