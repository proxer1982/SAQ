namespace SAQ.Domain.Entities
{
    public class PermissonMenu
    {
        public int PermissionMenuId { get; set; }
        public int MenuId { get; set; }
        public int PermissonId { get; set; }
        public int Status { get; set; }

        //public virtual Menu Menu { get; set; } = new Menu();
        public virtual Permisson? Permisson { get; set; }
    }
}
