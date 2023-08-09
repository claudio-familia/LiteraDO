using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.Controllers.Base;
using LiteraDO.DataAccess.Repositories.Contracts;
using LiteraDO.Domain.Writers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Text.Json;

namespace LiteraDO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoriesController : BaseController<Story, StoryDto>
    {
        private readonly IBaseService<Story, StoryDto> baseService;
        private readonly IBlobStorageService storageService;
        private readonly ICurrentUserService currentUserService;

        public StoriesController(IBaseService<Story, StoryDto> baseService, IBlobStorageService StorageService, ICurrentUserService currentUserService) : base(baseService)
        {
            this.baseService = baseService;
            storageService = StorageService;
            this.currentUserService = currentUserService;
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
    }
}
