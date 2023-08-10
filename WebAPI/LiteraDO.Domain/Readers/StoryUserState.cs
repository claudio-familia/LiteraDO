using LiteraDO.Domain.Users;
using LiteraDO.Domain.Writers;

namespace LiteraDO.Domain.Readers
{
    public class StoryUserState: BaseEntity
    {
        public int UserId { get; set; }
        public int StoryId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Rating { get; set; }
        public string RatingComment { get; set; }
        public DateTime LastReadingDate { get; set; }
        public string ChapterWhereTheyLeft { get; set; }

        public Story Story { get; set; }
        public User User { get; set; }
    }
}
