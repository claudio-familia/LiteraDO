using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.BusinessLogic.Services.Writers;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.DataAccess.Repositories.Contracts;
using LiteraDO.Domain.Readers;
using LiteraDO.Domain.Writers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System.Text.Json;

namespace LiteraDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoriesController : BaseController<Story, StoryDto>
    {
        private readonly IStoryService baseService;
        private readonly IBlobStorageService storageService;
        private readonly ICurrentUserService currentUserService;
        private readonly IDataRepository<StoryUserState> storyUserStateRepository;

        public StoriesController(
            IStoryService baseService, 
            IBlobStorageService StorageService, 
            ICurrentUserService currentUserService,
            IDataRepository<StoryUserState> storyUserStateRepository) : base(baseService)
        {
            this.baseService = baseService;
            storageService = StorageService;
            this.currentUserService = currentUserService;
            this.storyUserStateRepository = storyUserStateRepository;
        }

        [Route("{id}/publish")]
        [HttpPost]
        public IActionResult GetTitle(int id)
        {
            var response = baseService.Publish(id);

            return Ok(response);
        } 
        
        [Route("published")]
        [HttpGet]
        public IActionResult GetTitle()
        {
            var response = baseService.GetPublishStories();

            return Ok(response);
        }

        [Route("stories/my-story/reading")]
        [HttpGet]
        public IActionResult GetRadingStories()
        {
            var stories = storyUserStateRepository.GetAll(x => x.Include(x => x.Story)).Where(x => x.UserId == currentUserService.UserId.Value);

            return Ok(stories);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Post(
            [FromForm] string story,
            [FromForm] IFormFile asset
         )
        {
            var _story = JsonSerializer.Deserialize<StoryDto>(story);
            var userId = currentUserService.UserId.Value;
            _story.UserId = userId;
            _story.CopyrightType = "All rights reserved";
            if (asset == null) return BadRequest("File is not valid");

            var fileName = $"{_story.Title}_{_story.UserId}_{asset.FileName}";
            Stream stream = asset.OpenReadStream();
            storageService.UploadDocument(fileName, stream);
            _story.Cover = $"https://literadostorage.blob.core.windows.net/literado/{fileName}";
            
            var result = baseService.Add(_story);


            return Ok(result);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Put(
            [FromForm] string story,
            [FromForm] IFormFile? asset
         )
        {
            var _story = JsonSerializer.Deserialize<StoryDto>(story);
            if (asset != null)
            {
                var fileName = $"{_story.Title}_{_story.UserId}_{asset.FileName}";
                Stream stream = asset.OpenReadStream();
                storageService.UploadDocument(fileName, stream);
                _story.Cover = $"https://literadostorage.blob.core.windows.net/literado/{fileName}";
            }
            else
            {
                var savedStory = baseService.GetAll().FirstOrDefault(x => x.Id == _story.Id);
                _story.Cover = savedStory.Cover;
            }

            var result = baseService.Update(_story);


            return Ok(result);
        }

        [Route("{id}/chapterinfo/mark-read")]
        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            var entity = baseService.Get(x => x, x => x.Id == id);

            var response = storyUserStateRepository.Add(new StoryUserState()
            {
                StoryId = id,
                UserId = currentUserService.UserId.Value,
                Rating = 0,
                StartDate = DateTime.Now,
                ChapterWhereTheyLeft = "", 
                RatingComment = ""
            });

            return Ok(response);
        }

        [Route("{id}/chapterinfo/chapter/{chapterId}")]
        [HttpPost]
        public IActionResult SaveChapter(int id, int chapterId)
        {
            var entity = storyUserStateRepository.GetAll(x => x).FirstOrDefault(x => x.Id == id);

            entity.ChapterWhereTheyLeft = chapterId.ToString();

            var response = storyUserStateRepository.Update(entity);

            return Ok(response);
        }


        [Route("{id}/chapterinfo")]
        [HttpGet]
        public IActionResult GetChapterInfo(int id)
        {
            var entity = storyUserStateRepository.GetAll(x => x).FirstOrDefault(x => x.StoryId == id && x.UserId == currentUserService.UserId.Value);

            return Ok(entity);
        }
    }
}
