using FluentValidation;
using StudentInsight.DTOs.StudentDTOs;

namespace StudentInsight.Validators.Students
{
    public class FilterStudentValidator : AbstractValidator<StudentFilterDto>
    {
        public FilterStudentValidator()
        {
            RuleFor(s => s.CreatorUserId)
                .NotEmpty()
                .When(s => s.CreatorUserId.HasValue);

            RuleFor(s => s.FromRollNumber)
                .GreaterThan(0)
                .When(s => s.FromRollNumber.HasValue);

            RuleFor(s => s.ToRollNumber)
                .GreaterThan(0)
                .When(s => s.ToRollNumber.HasValue);

            RuleFor(s => s)
                .Must(s => s.FromRollNumber <= s.ToRollNumber)
                .When(s => s.FromRollNumber.HasValue && s.ToRollNumber.HasValue)
                .WithMessage("Roll number range 'From' must be less than or equal to 'To'.");

            RuleFor(s => s.PageNumber)
                .GreaterThan(0);

            RuleFor(s => s.PageSize)
                .InclusiveBetween(1, 100);
        }
    }
}
