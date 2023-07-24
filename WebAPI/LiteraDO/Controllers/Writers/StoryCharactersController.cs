using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.Domain.Writers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiteraDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoryCharactersController : BaseController<StoryCharacter, StoryCharacterDto>
    {
        public StoryCharactersController(IBaseService<StoryCharacter, StoryCharacterDto> baseService) : base(baseService)
        {
        }
    }
}
