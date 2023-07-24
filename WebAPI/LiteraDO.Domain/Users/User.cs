using LiteraDO.Common.Models.Enums;

namespace LiteraDO.Domain.Users
{
    public class User : BaseEntity
    {
        public int CountryId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public TargetPreference TargetPreference { get; set; }
        
        public Country Country { get; set; }
    }
}
