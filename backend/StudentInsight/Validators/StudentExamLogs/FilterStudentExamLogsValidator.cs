using FluentValidation;
using StudentInsight.DTOs.StudentExamLogsDTOs;

namespace StudentInsight.Validators.StudentExamLogs
{
    public class FilterStudentExamLogsValidator : AbstractValidator<StudentExamLogsFilterDto>
    {
        public FilterStudentExamLogsValidator()
        {
            RuleFor(l => l.CreatorUserId)
                .NotEmpty()
                .When(s => s.CreatorUserId.HasValue);

            RuleFor(l => l.ExamId)
                .NotEmpty()
                .When(l => l.ExamId.HasValue);

            RuleFor(l => l.Status)
                .IsInEnum()
                .When(l => l.Status.HasValue)
                .WithMessage("SEL Status can be either 'Pass' or 'Fail'.");

            RuleFor(l => l.MinObtainedMarks)
                .GreaterThan(0)
                .When(l => l.MinObtainedMarks.HasValue);

            RuleFor(l => l.MaxObtainedMarks)
                .GreaterThan(0)
                .When(l => l.MaxObtainedMarks.HasValue);

            RuleFor(l => l)
                .Must(l => l.MinObtainedMarks <= l.MaxObtainedMarks)
                .When(l => l.MinObtainedMarks.HasValue && l.MaxObtainedMarks.HasValue)
                .WithMessage("The number of 'Min' marks cannot exceed 'Max' marks.");

            RuleFor(l => l.PageNumber)
                .GreaterThan(0);

            RuleFor(l => l.PageSize)
                .InclusiveBetween(1, 100);
        }
    }
}
