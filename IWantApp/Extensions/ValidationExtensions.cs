using FluentValidation.Results;

namespace IWantApp.Extensions;

public static class ValidationExtensions
{
    public static IList<string> GetErrors(this ValidationResult validationResult)
    {
        return validationResult.Errors.Select(error => error.ErrorMessage).ToList();
    }
}