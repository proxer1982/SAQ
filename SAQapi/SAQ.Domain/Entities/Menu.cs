namespace SAQ.Domain.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public int? Parent { get; set; }
        public int? Order { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<PermissonMenu> PermissionMenus { get; set; } = new List<PermissonMenu>();
    }
}
