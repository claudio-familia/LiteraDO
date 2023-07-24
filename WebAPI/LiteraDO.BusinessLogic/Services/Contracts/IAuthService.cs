using System.IdentityModel.Tokens.Jwt;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Users;

namespace LiteraDO.BusinessLogic.Services.Contracts
{
    public interface IAuthService
    {
        public User Login(string username, string password);
        string GenerateJWT(User user);
        JwtPayload GetData(string token);
    }
}
