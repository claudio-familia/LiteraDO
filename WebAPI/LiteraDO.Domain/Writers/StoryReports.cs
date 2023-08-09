namespace LiteraDO.Domain.Writers
{
    public class StoryReports : BaseEntity
    {
        public int StoryId { get; set; }
        public string Reason { get; set; }
        public string Evidence { get; set; }
        public decimal Status { get; set; }

        public Story Story { get; set; }
    }
}
