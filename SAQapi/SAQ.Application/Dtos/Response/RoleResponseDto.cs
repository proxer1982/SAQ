using SAQ.Domain.Entities;

namespace SAQ.Application.Dtos.Response
{
    public class RoleResponseDto
    {
        public int RoleId { get; set; }
        public string Description { get; set; } = null!;
        public virtual ICollection<PermissonRole> PermissonRoles { get; set; } = new List<PermissonRole>();
    }
}
