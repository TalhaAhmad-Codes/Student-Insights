using FluentValidation;
using StudentInsight.DTOs.UserDTOs.UserUpdateDtos;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Users.UpdateUserValidators
{
    public class UpdateUserProfilePicValidator : AbstractValidator<UserUpdateProfilePicDto>
    {
        public UpdateUserProfilePicValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty();
        }
    }

    public class UpdateUserUsernameValidator : AbstractValidator<UserUpdateUsernameDto>
    {
        public UpdateUserUsernameValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty();

            RuleFor(u => u.Username)
                .NotEmpty()
                .MaximumLength(MaxLength.Username);
        }
    }

    public class UpdateUserPasswordValidator : AbstractValidator<UserChangePasswordDto>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty();

            RuleFor(u => u.OldPassword)
                .NotEmpty()
                .MinimumLength(MinLength.Password)
                .WithMessage($"Password length must be at least {MinLength.Password} characters.");

            RuleFor(u => u.NewPassword)
                .NotEmpty()
                .MinimumLength(MinLength.Password)
                .WithMessage($"Password length must be at least {MinLength.Password} characters.");

            RuleFor(u => u.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(MinLength.Password)
                .WithMessage($"Password length must be at least {MinLength.Password} characters.");

            RuleFor(u => u)
                .Must(u => u.NewPassword == u.ConfirmPassword)
                .WithMessage("Please confirm you password correctly.");
        }
    }
}
