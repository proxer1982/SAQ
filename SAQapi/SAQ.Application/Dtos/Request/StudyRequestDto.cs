namespace SAQ.Application.Dtos.Request
{
    public class StudyRequestDto
    {
        public int? StudyId { get; set; }
        public string StudyName { get; set; }
        public string StudyLocation { get; set; }
        public int Status { get; set; }
        public Guid UserId { get; set; }
    }
}

