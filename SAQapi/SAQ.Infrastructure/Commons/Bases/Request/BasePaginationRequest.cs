namespace SAQ.Infrastructure.Commons.Bases.Request
{
    public class BasePaginationRequest
    {
        public int NumPage { get; set; } = 1;
        public int NumRecorPage { get; set; } = 20;
        private readonly int _numMaxRecordsPage = 50;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;

        public int Records
        {
            get => NumRecorPage;
            set
            {
                NumRecorPage = value > _numMaxRecordsPage ? _numMaxRecordsPage : value;
            }
        }
    }
}