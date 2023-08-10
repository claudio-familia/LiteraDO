using LiteraDO.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraDO.BusinessLogic.Dto
{
    public class UserProfileDto
    {
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string LastName { get; set; }
        public int TargetPreference { get; set; }
        public string UserName { get; set; }
    }
}
