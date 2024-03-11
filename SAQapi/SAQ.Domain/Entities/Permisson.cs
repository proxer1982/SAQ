namespace SAQ.Domain.Entities
{
    public class Permisson
    {
        public int PermissonId { get; set; }
        public string Description { get; set; } = "";
        public int Status { get; set; }

        public virtual ICollection<PermissonRole> PermissonRoles { get; set; } = new List<PermissonRole>();
        public virtual ICollection<PermissonUser> PermissonUsers { get; set; } = new List<PermissonUser>();
        //public virtual ICollection<PermissonMenu> PermissonMenus { get; set; } = new List<PermissonMenu>();
    }
}
