using System.Security.Claims;
using Dapper;
using IWantApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace IWantApp.Infrastructure.Repositories.EmployeeRepository;

public class IdentityRepository : IIdentityRepository
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;

    public IdentityRepository(ApplicationContext context, IConfiguration configuration, UserManager<IdentityUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<IEnumerable<IdentityUser>> GetAllEmployeesWithClaimsAsync(int page, int pageSize)
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];

        await using var connection = new SqlConnection(connectionString);

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

        var employees = await connection.QueryAsync<IdentityUser>(query, pagination);

        return employees;
    }

    public async Task<IdentityResult> AddEmployeeAsync(IdentityUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> AddClaimsAsync(IdentityUser user, List<Claim> claims)
    {
        return await _userManager.AddClaimsAsync(user, claims);
    }
}