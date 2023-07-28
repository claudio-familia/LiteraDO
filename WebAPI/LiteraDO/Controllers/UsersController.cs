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
    [AllowAnonymous]
    public class UsersController : BaseController<User>
    {
        public UsersController(IBaseService<User> baseService) : base(baseService)
        {
        }

        [AllowAnonymous]
        public override IActionResult Post(User entity)
        {
            return base.Post(entity);
        }
    }
}
