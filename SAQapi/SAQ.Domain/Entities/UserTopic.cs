namespace SAQ.Domain.Entities
{
    public class UserTopic
    {
        public Guid UserTopicId { get; set; }
        public Guid UserId { get; set; }
        public int TopicId { get; set; }
        public double Score { get; set; }
        public int? Status { get; set; }

        public DateTime DateCreated { get; set; }
        public Guid? UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? UserDeleted { get; set; }

        //public virtual User? User { get; set; }
        public virtual Topic? Topic { get; set; }
        public virtual ICollection<TopicWork> TopicWorks { get; set; } = new List<TopicWork>();
    }
}
