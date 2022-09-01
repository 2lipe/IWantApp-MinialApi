using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Extensions;

public static class ValidationExtensions
{
    public static IList<string> GetErrors(this ValidationResult validationResult)
    {
        return validationResult.Errors.Select(error => error.ErrorMessage).ToList();
    }

    public static IList<string> GetIdentityErrors(this IdentityResult identityResult)
    {
        return identityResult.Errors.Select(error => error.Description).ToList();
    }
}