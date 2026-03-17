namespace StudentInsight.Entities.Common
{
    public abstract class CreatorBaseEntity : BaseEntity
    {
        // Foreign Key
        public Guid CreatorUserId { get; set; }

        // Navigation
        public User CreatorUser { get; set; }
    }
}
