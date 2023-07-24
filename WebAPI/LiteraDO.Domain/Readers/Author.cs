using LiteraDO.Domain.Users;

namespace LiteraDO.Domain.Readers
{
    public class Author : BaseEntity
    {
        public int CountryId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }

        public Country Country { get; set; }
    }
}
