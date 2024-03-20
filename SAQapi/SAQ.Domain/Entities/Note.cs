namespace SAQ.Domain.Entities
{
    public class Note
    {
        public Guid NoteId { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; } = 1;
        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }
        public Guid? UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? UserDeleted { get; set; }

        //public virtual User? user { get; set; }
    }
}
