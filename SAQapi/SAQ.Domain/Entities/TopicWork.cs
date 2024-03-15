namespace SAQ.Domain.Entities
{
    public class TopicWork
    {
        public Guid TopicWorkId { get; set; }
        public Guid WorkId { get; set; }
        public Guid UserTopicId { get; set; }
        public int? Status { get; set; }

        public DateTime DateCreated { get; set; }
        public Guid? UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? UserDeleted { get; set; }

        //public virtual UserTopic? UserTopic { get; set; }
        public virtual Work? Work { get; set; }
    }
}
