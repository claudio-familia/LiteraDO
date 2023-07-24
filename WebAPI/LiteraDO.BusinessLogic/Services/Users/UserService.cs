using AutoMapper;
using Microsoft.Extensions.Configuration;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.DataAccess.Repositories.Contracts;
using LiteraDO.Domain.Users;

namespace LiteraDO.BusinessLogic.Services.Users
{
    public class UserService : BaseService<User, UserDto>, IBaseService<User, UserDto>
    {
        private readonly ICryptographyService _crytographyService;
        private readonly IConfiguration _configuration;

        public UserService(IDataRepository<User> _repository,
                           ICryptographyService crytographyService,
                           IConfiguration configuration,
                           ICurrentUserService currentUser,
                           IMapper mapper) : base(_repository, mapper)
        {
            this._crytographyService = crytographyService;
            this._configuration = configuration;
        }

        public override User Add(UserDto entity)
        {
            entity.Password = _crytographyService.Encrypt(entity.Password, _configuration["Authentication:SecretKey"]);

            return base.Add(entity);
        }
    }
}
