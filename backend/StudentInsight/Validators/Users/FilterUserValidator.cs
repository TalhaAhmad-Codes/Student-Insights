using FluentValidation;
using StudentInsight.DTOs.UserDTOs;

namespace StudentInsight.Validators.Users
{
    public class FilterUserValidator : AbstractValidator<UserFilterDto>
    {
        public FilterUserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .When(u => u.Email != null);

            RuleFor(s => s.PageNumber)
                .GreaterThan(0);

            RuleFor(s => s.PageSize)
                .InclusiveBetween(1, 100);
        }
    }
}
