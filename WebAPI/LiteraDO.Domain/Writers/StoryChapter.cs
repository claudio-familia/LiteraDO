namespace LiteraDO.Domain.Writers
{
    public class StoryChapter : BaseEntity
    {
        public int StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Story Story { get; set; }
    }
}
