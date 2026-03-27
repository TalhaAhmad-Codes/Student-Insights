using FluentValidation;
using StudentInsight.DTOs.SubjectDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Subject
{
    public class FilterSubjectValidator : AbstractValidator<SubjectFilterDto>
    {
        public FilterSubjectValidator()
        {
            RuleFor(s => s.CreatorUserId)
                .NotEmpty()
                .When(s => s.CreatorUserId.HasValue);

            RuleFor(s => s.Name)
                .MaximumLength(MaxLength.SubjectName)
                .NotEmpty()
                .When(s => s.Name != null);

            RuleFor(s => s.PageNumber)
                .GreaterThan(0);

            RuleFor(s => s.PageSize)
                .InclusiveBetween(1, 100);
        }
    }
}
