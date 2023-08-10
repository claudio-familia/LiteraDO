using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.Domain.Users;
using LiteraDO.BusinessLogic.Services;
using LiteraDO.Common.Services;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.Common.Models.Enums;

namespace LiteraDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController : BaseController<User, UserDto>
    {
        private readonly IBaseService<User, UserDto> baseService;
        private readonly ICurrentUserService currentUserService;

        public UsersController(IBaseService<User, UserDto> baseService, ICurrentUserService currentUserService) : base(baseService)
        {
            this.baseService = baseService;
            this.currentUserService = currentUserService;
        }

        [Route("profile")]
        [HttpGet]
        public IActionResult GetProfile()
        {
            var userId = currentUserService.UserId.Value;

            var result = baseService.Get(userId);

            return Ok(result);
        }

        [Route("profile")]
        [HttpPut]
        public IActionResult UpdateProfile(UserProfileDto user)
        {
            var userId = currentUserService.UserId.Value;

            var _user = baseService.GetAll().FirstOrDefault(x => x.Id == userId);

            _user.BirthDate = user.BirthDate;
            _user.CountryId = user.CountryId;
            _user.Email = user.Email;
            _user.FirstName = user.FirstName;
            _user.Gender = user.Gender;
            _user.LastName = user.LastName;
            _user.TargetPreference = user.TargetPreference;
            _user.UserName = user.UserName;

            var result = baseService.Update(_user);

            return Ok(result);
        }

        [AllowAnonymous]
        public override IActionResult Post(UserDto entity)
        {
            return base.Post(entity);
        }
    }
}
