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
    public class AuthorsController : BaseController<Author, AuthorDto>
    {
        public AuthorsController(IBaseService<Author, AuthorDto> baseService) : base(baseService)
        {
        }
    }
}
