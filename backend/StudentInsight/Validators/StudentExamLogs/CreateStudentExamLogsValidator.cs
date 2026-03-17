using FluentValidation;
using StudentInsight.DTOs.StudentExamLogsDTOs;

namespace StudentInsight.Validators.StudentExamLogs
{
    public class CreateStudentExamLogsValidator : AbstractValidator<StudentExamLogsCreateDto>
    {
        public CreateStudentExamLogsValidator()
        {
            RuleFor(l => l.CreatorUserId)
                .NotEmpty();

            RuleFor(l => l.ExamId)
                .NotEmpty();

            RuleFor(l => l.ObtainedMarks)
                .GreaterThan(0);

            RuleFor(l => l.Note)
                .NotEmpty()
                .When(l => l.Note != null);

            RuleFor(l => l.Status)
                .IsInEnum()
                .WithMessage("SEL Status can be either 'Pass' or 'Fail'.");
        }
    }
}
