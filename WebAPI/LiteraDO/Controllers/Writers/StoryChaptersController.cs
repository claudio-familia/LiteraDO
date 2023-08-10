using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.DataAccess.Repositories.Contracts;
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
        private readonly ICurrentUserService currentUserService;

        public StoryChaptersController(
            IBaseService<StoryChapter, StoryChapterDto> baseService,
            IStoryService storyService,
            ICurrentUserService currentUserService) : base(baseService)
        {
            this.baseService = baseService;
            this.storyService = storyService;
            this.currentUserService = currentUserService;
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
