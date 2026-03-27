using FluentValidation;
using StudentInsight.DTOs.ExamDTOs;
using StudentInsight.Enums;

namespace StudentInsight.Validators.Exams
{
    public class CreateExamValidator : AbstractValidator<ExamCreateDto>
    {
        public CreateExamValidator()
        {
            RuleFor(e => e.CreatorUserId)
                .NotEmpty();

            RuleFor(e => e.SubjectId)
                .NotEmpty();

            RuleFor(e => e.TotalMarks)
                .GreaterThan(0);

            RuleFor(e => e.Type)
                .IsInEnum()
                .WithMessage("Exam type can be 'Sessional', 'Mid', or 'Final'");
        }
    }
}
