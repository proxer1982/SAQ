namespace SAQ.Domain.Entities
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string? Description { get; set; }
        public string? UrlLogo { get; set; }
        public int Status { get; set; } = 1;


        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UserCreated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? UserDeleted { get; set; }

        /*public virtual ICollection<Work> Works { get; set; } = new List<Work>();
        public virtual ICollection<UserTopic> UserTopics { get; set; } = new List<UserTopic>();*/
    }
}
