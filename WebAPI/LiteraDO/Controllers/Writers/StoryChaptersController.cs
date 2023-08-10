using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.Domain.Writers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiteraDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoryChaptersController : BaseController<StoryChapter, StoryChapterDto>
    {
        private readonly IBaseService<StoryChapter, StoryChapterDto> baseService;
        private readonly IStoryService storyService;

        public StoryChaptersController(
            IBaseService<StoryChapter, StoryChapterDto> baseService,
            IStoryService storyService) : base(baseService)
        {
            this.baseService = baseService;
            this.storyService = storyService;
        }

        [Route("{id}/story-title")]
        [HttpGet]
        public IActionResult GetTitle(int id)
        {
            var response = storyService.Get(x => x, x => x.Id == id);

            return Ok(response);
        }
    }
}
