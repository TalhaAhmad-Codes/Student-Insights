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
                .Must(p => !string.IsNullOrWhiteSpace(p))
                .MinimumLength(MinLength.Password);

            RuleFor(u => u.NewPassword)
                .Must(p => !string.IsNullOrWhiteSpace(p))
                .MinimumLength(MinLength.Password);

            RuleFor(u => u.ConfirmPassword)
                .Must(p => !string.IsNullOrWhiteSpace(p))
                .MinimumLength(MinLength.Password);
        }
    }
}
