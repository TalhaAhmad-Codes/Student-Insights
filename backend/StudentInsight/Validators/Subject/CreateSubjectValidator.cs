using FluentValidation;
using StudentInsight.DTOs.SubjectDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Subject
{
    public class CreateSubjectValidator : AbstractValidator<SubjectCreateDto>
    {
        public CreateSubjectValidator()
        {
            RuleFor(s => s.CreatorUserId)
                .NotEmpty();
            
            RuleFor(s => s.Name)
                .MaximumLength(MaxLength.SubjectName)
                .NotEmpty();
        }
    }
}
