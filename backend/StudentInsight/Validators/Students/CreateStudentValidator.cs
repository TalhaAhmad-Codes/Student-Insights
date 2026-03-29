using FluentValidation;
using StudentInsight.DTOs.StudentDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Students
{
    public class CreateStudentValidator : AbstractValidator<StudentCreateDto>
    {
        public CreateStudentValidator()
        {
            RuleFor(s => s.CreatorUserId)
                .NotEmpty();

            RuleFor(s => s.StudentName)
                .NotEmpty()
                .MaximumLength(MaxLength.PersonName);

            RuleFor(s => s.RollNumber)
                .GreaterThan(0);
        }
    }
}
