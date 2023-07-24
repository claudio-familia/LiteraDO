namespace LiteraDO.BusinessLogic.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public int LiteraryGenreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal Rating { get; set; }
        public decimal Reads { get; set; }
        public string Tags { get; set; }
        public string TagetAudience { get; set; }
        public string Language { get; set; }
        public bool HasAdultContent { get; set; }
    }
}
