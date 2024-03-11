namespace SAQ.Domain.Entities
{
    public class Career
    {
        public int CareerId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Status { get; set; } = 1;

        public DateTime DateCreated { get; set; }
        public Guid? UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? UserDeleted { get; set; }

        //public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<CareerPosition>? CareerPositions { get; set; } = new List<CareerPosition>();
    }
}
