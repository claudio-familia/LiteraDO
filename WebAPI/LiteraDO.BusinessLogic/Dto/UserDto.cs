using LiteraDO.Common.Models.Enums;
using LiteraDO.Domain.Users;

namespace LiteraDO.BusinessLogic.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int TargetPreference { get; set; }

        public Country? Country { get; set; }
    }
}
