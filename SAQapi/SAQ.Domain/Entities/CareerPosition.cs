namespace SAQ.Domain.Entities
{
    public class CareerPosition
    {
        public int CareerPositionId { get; set; }
        public int CareerId { get; set; }
        public int PositionId { get; set; }

        //public virtual Career Career { get; set; } = new Career();
        public virtual Position Position { get; set; } = new Position();
    }
}
