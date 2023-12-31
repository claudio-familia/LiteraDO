﻿using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.BusinessLogic.Services.Users;
using LiteraDO.BusinessLogic.Services.Writers;
using LiteraDO.Common.Services;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.Domain.Readers;
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
            services.AddScoped<IBlobStorageService, BlobStorageService >();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBaseService<User, UserDto>, UserService>();            

            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IBaseService<StoryChapter, StoryChapterDto>, BaseService<StoryChapter, StoryChapterDto>>();
            services.AddScoped<IBaseService<Country, CountryDto>, BaseService<Country, CountryDto>>();
            services.AddScoped<IBaseService<LiteraryGenre, LiteraryGenreDto>, BaseService<LiteraryGenre, LiteraryGenreDto>>();
        }
    }
}
