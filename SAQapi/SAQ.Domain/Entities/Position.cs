namespace SAQ.Domain.Entities
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Title { get; set; } = null!;
        public int Status { get; set; }

        //public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<CareerPosition> CareerPositions { get; set; } = new List<CareerPosition>();
    }
}
