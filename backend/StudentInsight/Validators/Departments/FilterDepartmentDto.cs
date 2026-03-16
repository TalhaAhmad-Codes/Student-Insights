using FluentValidation;
using StudentInsight.DTOs.DepartmentDTOs;
using StudentInsight.Validators.Length;

namespace StudentInsight.Validators.Departments
{
    public class FilterDepartmentDto : AbstractValidator<DepartmentFilterDto>
    {
        public FilterDepartmentDto()
        {
            RuleFor(s => s.CreatorUserId)
                .NotEmpty();

            RuleFor(s => s.Name)
                .Must(n => !string.IsNullOrWhiteSpace(n))
                .MaximumLength(MaxLength.DepartmentName)
                .When(s => s.Name != null);

            RuleFor(s => s.PageNumber)
                .GreaterThan(0);

            RuleFor(s => s.PageSize)
                .InclusiveBetween(1, 100);
        }
    }
}
