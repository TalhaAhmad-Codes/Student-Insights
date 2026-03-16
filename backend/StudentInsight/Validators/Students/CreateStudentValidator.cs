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
                .Must(n => !string.IsNullOrWhiteSpace(n))
                .MaximumLength(MaxLength.PersonName);

            RuleFor(s => s.FatherName)
                .Must(n => !string.IsNullOrWhiteSpace(n))
                .MaximumLength(MaxLength.PersonName);

            RuleFor(s => s.DepartmentId)
                .NotEmpty();

            RuleFor(s => s.RollNumber)
                .GreaterThan(0);

            RuleFor(s => s.DateOfBirth)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage("Date of birth cannot be in the future.");
        }
    }
}
