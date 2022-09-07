using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Infrastructure.Repositories.EmployeeRepository;

public interface IIdentityRepository
{
    Task<IEnumerable<IdentityUser>> GetAllEmployeesWithClaimsAsync(int page, int pageSize);
    Task<IdentityResult> AddEmployeeAsync(IdentityUser user, string password);
    Task<IdentityResult> AddClaimsAsync(IdentityUser user, List<Claim> claims);
}