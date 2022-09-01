using FluentValidation;

namespace IWantApp.Dtos.Employee;

public record CreateEmployeeDto(string Name, string Email, string Password, string EmployeeCode)
{
    public class Validator : AbstractValidator<CreateEmployeeDto>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(2);

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(6);

            RuleFor(x => x.EmployeeCode)
                .NotNull()
                .NotEmpty();
        }
    }
}