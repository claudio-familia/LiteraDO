﻿namespace LiteraDO.Domain.Readers
{
    public class Book : BaseEntity
    {
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

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public LiteraryGenre LiteraryGenre { get; set; }
    }
}
