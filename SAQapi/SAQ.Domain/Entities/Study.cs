namespace SAQ.Domain.Entities
{
    public class Study
    {
        public int StudyId { get; set; }
        public string? StudyName { get; set; }
        public string? StudyLocation { get; set; }
        public int Status { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid? UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? UserDeleted { get; set; }
    }
}
