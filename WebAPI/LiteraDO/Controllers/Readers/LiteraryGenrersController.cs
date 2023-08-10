using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.Domain.Readers;
using LiteraDO.Domain.Writers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiteraDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LiteraryGenresController : BaseController<LiteraryGenre, LiteraryGenreDto>
    {
        public LiteraryGenresController(IBaseService<LiteraryGenre, LiteraryGenreDto> baseService) : base(baseService)
        {
        }

        [AllowAnonymous]
        public override IActionResult Get()
        {
            return base.Get();
        }
    }
}
