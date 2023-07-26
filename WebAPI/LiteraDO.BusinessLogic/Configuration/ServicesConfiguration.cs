using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.BusinessLogic.Services.Users;
using LiteraDO.BusinessLogic.Services.Writers;
using LiteraDO.Common.Services;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.Domain.Users;
using LiteraDO.Domain.Writers;
using Microsoft.Extensions.DependencyInjection;

namespace LiteraDO.DataAccess.Configuration
{
    public static partial class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICryptographyService, CryptographyService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBaseService<User, UserDto>, UserService>();            

            services.AddScoped<IBaseService<Story, StoryDto>, StoryService>();
            services.AddScoped<IBaseService<Country, CountryDto>, BaseService<Country, CountryDto>>();
        }
    }
}
