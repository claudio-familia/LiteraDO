namespace LiteraDO.Domain.Writers
{
    public class StoryReviews: BaseEntity
    {
        public int StoryChapterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
