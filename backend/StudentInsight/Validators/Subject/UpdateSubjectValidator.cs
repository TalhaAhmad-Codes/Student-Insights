using FluentValidation;
using StudentInsight.DTOs.SubjectDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Subject
{
    public class UpdateSubjectValidator : AbstractValidator<SubjectUpdateDto>
    {
        public UpdateSubjectValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty();

            RuleFor(s => s.Name)
                .MaximumLength(MaxLength.SubjectName)
                .NotEmpty();
        }
    }
}
