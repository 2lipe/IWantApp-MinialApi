using FluentValidation;

namespace IWantApp.Dtos.Category;

public record UpdateCategoryDto(string Name, bool HasActive)
{
    public class Validator : AbstractValidator<UpdateCategoryDto>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(2);
        }
    }
}