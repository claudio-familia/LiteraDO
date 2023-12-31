using System;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using Xunit;
using Moq;
using LiteraDO.Domain.Users;

namespace LiteraDO.BusinessLogic
{
    public class AuthServiceTest
    {
        private readonly LoginDto _loginUser;
        private readonly User _user;
        private readonly Mock<IAuthService> _authService;
        public AuthServiceTest()
        {
            _loginUser = new LoginDto()
            {
                UserName = "String",
                Password = "String"
            };

            _user = new User()
            {
                BirthDate = DateTime.Now,
                CreationTime = DateTime.Now,
                LastModificationTime = DateTime.Now,
                DeletionTime = DateTime.Now,
                CreatorUserId = 0,
                LastModifierUserId = 0,
                DeleterUserId = 0,
                Email = "string@string.com",
                FirstName = "String",
                Gender = "M",
                Id = 1,
                IsDeleted = false,
                LastName = "String",
                CountryId = 1,
                Password = "String",
                UserName = "String",
            };

            _authService = new Mock<IAuthService>();

            _authService.Setup(service => service.GenerateJWT(It.IsAny<User>())).Returns("Some Generated JWT");
        }

        [Fact]
        public void ShouldReturnUserObjectWithValidatedUser()
        {
            _authService.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(_user);

            var user = _authService.Object.Login(_loginUser.UserName, _loginUser.Password);

            _authService.Verify(x => x.Login(_loginUser.UserName, _loginUser.Password), Times.Once);

            Assert.Equal(user, _user);
        }

        [Fact]
        public void ShouldReturnNullObjectWithInValidatedUser()
        {
            _authService.Setup(service => service.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(new User());

            var user = _authService.Object.Login(_loginUser.UserName, _loginUser.Password);

            _authService.Verify(x => x.Login(_loginUser.UserName, _loginUser.Password), Times.Once);

            Assert.NotEqual(user, _user);
            Assert.NotSame(user, _user);
        }

        [Fact]
        public void ShouldReturnJWTTokenWithValidatedUser()
        {
            var jwtToken = _authService.Object.GenerateJWT(_user);

            Assert.True(jwtToken.Length > 0);
        }
    }
}
