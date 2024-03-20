using SAQ.Domain.Entities;

namespace SAQ.Application.Dtos.Response
{
    public class UserResponseDto
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public int PositionId { get; set; }
        //public string? PositionTitle { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UrlImage { get; set; }
        public DateTime DateCreated { get; set; }
        public int Status { get; set; }
        public string? StatusUser { get; set; }

        public virtual PositionResponseDto? Position { get; set; } = null;

        //public virtual Career? Career { get; set; }
        public virtual RoleResponseDto? Rol { get; set; } = new RoleResponseDto();
        //public virtual Position? Position { get; set; }
        public virtual ICollection<int>? Permisson { get; set; } = new List<int>();

        public int? CareerId { get; set; }
        public int? StateCareer { get; set; }
        public string? Alias { get; set; }
        public int? TeamId { get; set; }
        public ICollection<Study>? Study { get; set; } = new List<Study>();
        public bool? SoftSkills { get; set; }


        //public virtual ICollection<Note>? Notes { get; set; }
        public virtual Team? Team { get; set; }
        //public virtual ICollection<UserTopic>? UserTopics { get; set; } = new List<UserTopic>();

    }
}
