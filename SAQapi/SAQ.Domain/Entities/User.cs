namespace SAQ.Domain.Entities
{
    public class User
    {
        public Guid? UserId { get; set; }
        public int RoleId { get; set; }
        public int? CareerId { get; set; }
        public int? StateCareer { get; set; }
        public required string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Alias { get; set; }
        public int? TeamId { get; set; }
        public bool? SoftSkills { get; set; } = false;
        public string? Password { get; set; }
        public int PositionId { get; set; }
        public string? UrlImage { get; set; }
        public int? Status { get; set; } = 1;
        public string? ActiveTkn { get; set; }

        public DateTime DateCreated { get; set; }
        public Guid? UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UserUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? UserDeleted { get; set; }

        public virtual ICollection<Note>? Notes { get; set; }
        public virtual Career? Career { get; set; }
        public virtual Role? Rol { get; set; }
        public virtual Position? Position { get; set; }
        public virtual Team? Team { get; set; }
        public virtual ICollection<Study> Study { get; set; } = new List<Study>();
        public virtual ICollection<UserTopic>? UserTopics { get; set; } = new List<UserTopic>();
        public virtual ICollection<PermissonUser> PermissonUsers { get; set; } = new List<PermissonUser>();

    }
}
