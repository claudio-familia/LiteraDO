namespace LiteraDO.BusinessLogic.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
