using Microsoft.Extensions.Configuration;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.DataAccess.Repositories.Contracts;
using LiteraDO.Domain.Users;

namespace LiteraDO.BusinessLogic.Services.Users
{
    public class UserService : BaseService<User>, IBaseService<User>
    {
        private readonly ICryptographyService _crytographyService;
        private readonly IConfiguration _configuration;

        public UserService(IDataRepository<User> _repository,
                           ICryptographyService crytographyService,
                           IConfiguration configuration,
                           ICurrentUserService currentUser) : base(_repository)
        {
            this._crytographyService = crytographyService;
            this._configuration = configuration;
        }

        public override User Add(User entity)
        {
            entity.Password = _crytographyService.Encrypt(entity.Password, _configuration["Authentication:SecretKey"]);

            return base.Add(entity);
        }
    }
}
