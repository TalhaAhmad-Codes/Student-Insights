using FluentValidation;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Students
{
    public class UpdateStudentValidator : AbstractValidator<StudentUpdateDto>
    {
        public UpdateStudentValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty();

            RuleFor(s => s.StudentName)
                .NotEmpty()
                .MaximumLength(MaxLength.PersonName);

            RuleFor(s => s.RollNumber)
                .GreaterThan(0);
        }
    }
}
