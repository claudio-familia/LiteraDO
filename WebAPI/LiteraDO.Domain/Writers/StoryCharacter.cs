namespace LiteraDO.Domain.Writers
{
    public class StoryCharacter : BaseEntity
    {
        public int StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Age { get; set; }

        public Story Story { get; set; }
    }
}
