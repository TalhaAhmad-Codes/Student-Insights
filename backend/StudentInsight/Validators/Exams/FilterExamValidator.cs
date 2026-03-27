using FluentValidation;
using StudentInsight.DTOs.ExamDTOs;

namespace StudentInsight.Validators.Exams
{
    public class FilterExamValidator : AbstractValidator<ExamFilterDto>
    {
        public FilterExamValidator()
        {
            RuleFor(e => e.CreatorUserId)
                .NotEmpty()
                .When(s => s.CreatorUserId.HasValue);

            RuleFor(e => e.SubjectId)
                .NotEmpty()
                .When(e => e.SubjectId.HasValue);

            RuleFor(e => e.MinTotalMarks)
                .GreaterThan(0)
                .When(e => e.MinTotalMarks.HasValue);

            RuleFor(e => e.MaxTotalMarks)
                .GreaterThan(0)
                .When(e => e.MaxTotalMarks.HasValue);

            RuleFor(e => e)
                .Must(e => e.MinTotalMarks <= e.MaxTotalMarks)
                .When(e => e.MinTotalMarks.HasValue && e.MaxTotalMarks.HasValue)
                .WithMessage("The number of 'Min' marks cannot exceed 'Max' marks.");

            RuleFor(e => e.PageNumber)
                .GreaterThan(0);

            RuleFor(e => e.PageSize)
                .InclusiveBetween(1, 100);
        }
    }
}
