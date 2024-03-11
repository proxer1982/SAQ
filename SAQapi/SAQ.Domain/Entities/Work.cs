namespace SAQ.Domain.Entities
{
    public class Work
    {
        public Guid WorkId { get; set; }
        public string Description { get; set; } = "";
        public int Score { get; set; }
        public int TopicId { get; set; }
        public int Status { get; set; } = 1;


        public DateTime DateCreated { get; set; }
        public Guid? UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? UserDeleted { get; set; }

        public virtual Topic Topic { get; set; } = new Topic();
        public virtual ICollection<TopicWork> TopicWorks { get; set; } = new List<TopicWork>();
    }
}
