using StudentInsight.DTOs.SubjectDTOs;
using StudentInsight.Entities;

namespace StudentInsight.Mappers
{
    public static class SubjectMapper
    {
        public static SubjectRepsonseDto ToDto(Subject subject)
            => new()
            {
                Id = subject.Id,
                CreatorUserId = subject.CreatorUserId,
                Name = subject.Name,
                CreatedAt = subject.CreatedAt
            };

        public static Subject ToEntity(SubjectCreateDto subject)
            => new()
            {
                Name = subject.Name,
                CreatorUserId = subject.CreatorUserId
            };
    }
}
