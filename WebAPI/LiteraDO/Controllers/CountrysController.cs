using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiteraDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : BaseController<Country>
    {
        public CountriesController(IBaseService<Country> baseService) : base(baseService)
        {
        }

        [AllowAnonymous]
        public override IActionResult Get()
        {
            return base.Get();
        }
    }
}
