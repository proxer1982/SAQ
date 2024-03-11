namespace SAQ.Domain.Entities
{
    public class PermissonUser
    {
        public int PermissonUserId { get; set; }
        public Guid UserId { get; set; }
        public int PermissonId { get; set; }
        public int Status { get; set; }

        public virtual User User { get; set; }
        public virtual Permisson Permisson { get; set; } = new Permisson();
    }
}
