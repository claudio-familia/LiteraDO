namespace LiteraDO.BusinessLogic.Dto
{
    public class StoryChapterDto
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Lines => Description.Split('\n').Length;
    }
}
