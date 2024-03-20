namespace SAQ.Application.Dtos.Request
{
    public class UserRequestDto
    {
        public int RoleId { get; set; }
        public required string UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Alias { get; set; }
        public bool? SoftSkills { get; set; }
        public ICollection<StudyRequestDto>? Study { get; set; } = new List<StudyRequestDto>();
        public int PositionId { get; set; }
        public int? CareerId { get; set; }
        public int? TeamId { get; set; }
        public string? UrlImage { get; set; }
        public int? Status { get; set; }
    }
}

