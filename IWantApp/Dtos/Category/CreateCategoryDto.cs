using FluentValidation;

namespace IWantApp.Dtos.Category;

public record CreateCategoryDto(string Name)
{
    public class Validator : AbstractValidator<CreateCategoryDto>
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