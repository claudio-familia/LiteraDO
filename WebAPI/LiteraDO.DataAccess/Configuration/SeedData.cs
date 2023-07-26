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

            if (saveChanges) context.SaveChanges();
        }
    }
}
