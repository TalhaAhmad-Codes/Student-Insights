using FluentValidation;
using StudentInsight.DTOs.ExamDTOs;

namespace StudentInsight.Validators.Exams
{
    public class UpdateExamValidator : AbstractValidator<ExamUpdateDto>
    {
        public UpdateExamValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();

            RuleFor(e => e.DepartmentId)
                .NotEmpty();

            RuleFor(e => e.TotalMarks)
                .GreaterThan(0);

            RuleFor(e => e.Type)
                .IsInEnum()
                .WithMessage("Exam type can be 'Sessional', 'Mid', or 'Final'");
        }
    }
}
