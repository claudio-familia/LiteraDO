using LiteraDO.Domain.Users;

namespace LiteraDO.Domain.Readers
{
    public class UserFavoriteGenre : BaseEntity
    {
        public int UserId { get; set; }
        public int LiteraryGenreId { get; set; }

        public User User { get; set; }
        public LiteraryGenre Genre { get; set; }
    }
}
