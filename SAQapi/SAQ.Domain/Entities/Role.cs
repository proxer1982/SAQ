namespace SAQ.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Description { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<PermissonRole> PermissonRoles { get; set; } = new List<PermissonRole>();
        //public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
