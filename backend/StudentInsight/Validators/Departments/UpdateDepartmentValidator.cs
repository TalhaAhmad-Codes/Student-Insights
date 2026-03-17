using FluentValidation;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Departments
{
    public class UpdateDepartmentValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty();

            RuleFor(d => d.Name)
                .NotEmpty()
                .MaximumLength(MaxLength.DepartmentName);
        }
    }
}
