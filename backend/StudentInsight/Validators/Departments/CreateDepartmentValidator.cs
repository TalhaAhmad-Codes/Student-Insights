using FluentValidation;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Departments
{
    public class CreateDepartmentValidator : AbstractValidator<DepartmentCreateDto>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(d => d.CreatorUserId)
                .NotEmpty();

            RuleFor(d => d.Name)
                .NotEmpty()
                .MaximumLength(MaxLength.DepartmentName);
        }
    }
}
