namespace SAQ.Domain.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Title { get; set; } = null!;
        public int Status { get; set; }
    }
}
