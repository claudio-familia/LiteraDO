using LiteraDO.Domain.Users;

namespace LiteraDO.Domain.Readers
{
    public class BookUserState: BaseEntity
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Rating { get; set; }
        public string RatingComment { get; set; }
        public DateTime LastReadingDate { get; set; }
        public string ChapterWhereTheyLeft { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
