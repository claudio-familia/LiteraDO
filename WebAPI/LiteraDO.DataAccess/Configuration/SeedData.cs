using LiteraDO.Domain.Readers;
using LiteraDO.Domain.Users;

namespace LiteraDO.DataAccess.Configuration
{
    public class DataSeeder
    {
        public static void SeedData(LiteraDODBContext context)
        {
            bool saveChanges = false;
            if (!context.Countries.Any())
            {
                context.Add(new Country()
                {
                    CreationTime = DateTime.Now,
                    CreatorUserId = 0,
                    Description = "La República Dominicana es un país de América situado en el Caribe, ubicado en la zona central de las Antillas",
                    Name = "República Dominicana",
                    Id = 1
                });

                saveChanges = true;
            }

            if (!context.Users.Any())
            {
                context.Add(new User
                {
                    Id = 1,
                    CountryId = 1,
                    UserName = "Admin",
                    Email = "claudio.familia.morel@gmail.com",
                    Gender = "N/A",
                    BirthDate = DateTime.Now,
                    Password = "hAOxstupHx0=", // 1234
                    TargetPreference = Common.Models.Enums.TargetPreference.Both,
                    FirstName = "William",
                    LastName = "Shakespeare"
                });

                saveChanges = true;
            }

            if (!context.LiteraryGenres.Any())
            {
                context.AddRange(
                    new LiteraryGenre() { Id = 1, Name = "Acción", Description = "" },
                    new LiteraryGenre() { Id = 2, Name = "Aventura", Description = "" },
                    new LiteraryGenre() { Id = 3, Name = "FanFiction", Description = "" },
                    new LiteraryGenre() { Id = 4, Name = "Fantasia", Description = "" },
                    new LiteraryGenre() { Id = 5, Name = "General", Description = "" },
                    new LiteraryGenre() { Id = 6, Name = "Horror", Description = "" },
                    new LiteraryGenre() { Id = 7, Name = "Humor", Description = "" },
                    new LiteraryGenre() { Id = 8, Name = "Misterio", Description = "" },
                    new LiteraryGenre() { Id = 9, Name = "Paranormal", Description = "" },
                    new LiteraryGenre() { Id = 10, Name = "Spiritual", Description = "" },
                    new LiteraryGenre() { Id = 11, Name = "Casos de la vida", Description = "" }
                );

                saveChanges = true;
            }

            if (saveChanges) context.SaveChanges();
        }
    }
}
