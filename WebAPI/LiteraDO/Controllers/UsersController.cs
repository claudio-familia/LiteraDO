using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.Domain.Users;

namespace LiteraDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : BaseController<User, UserDto>
    {
        public UsersController(IBaseService<User, UserDto> baseService) : base(baseService)
        {
        }

        [AllowAnonymous]
        public override IActionResult Post(UserDto entity)
        {
            return base.Post(entity);
        }
    }
}
