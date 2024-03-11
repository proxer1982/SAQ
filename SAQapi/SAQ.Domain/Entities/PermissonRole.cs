namespace SAQ.Domain.Entities
{
    public class PermissonRole
    {
        public int PermissonRoleId { get; set; }
        public int PermissonId { get; set; }
        public int RoleId { get; set; }
        public int? Status { get; set; }

        public virtual Permisson? Permisson { get; set; }
        public virtual Role? Role { get; set; }
    }
}
