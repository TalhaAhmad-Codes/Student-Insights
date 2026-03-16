using FluentValidation;
using StudentInsight.DTOs.UserDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<UserCreateDto>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Username)
                .Must(n => !string.IsNullOrWhiteSpace(n))
                .MaximumLength(MaxLength.Username);

            RuleFor(u => u.Email)
                .NotEmpty()
                .MaximumLength(MaxLength.Email)
                .EmailAddress();

            RuleFor(u => u.Password)
                .Must(p => !string.IsNullOrWhiteSpace(p))
                .MinimumLength(MinLength.Password);
        }
    }
}
