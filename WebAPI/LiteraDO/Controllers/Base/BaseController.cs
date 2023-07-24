using Microsoft.AspNetCore.Mvc;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Common.Models;

namespace LiteraDO.Controllers.Base
{
    public class BaseController<T, Dto> : ControllerBase
        where T : class, IAuditableEntity, new()
        where Dto : class, new()
    {
        private readonly IBaseService<T, Dto> _baseService;
        public BaseController(IBaseService<T, Dto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_baseService.GetAll());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var response = _baseService.Get(id);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public virtual IActionResult Post(Dto entity)
        {
            var response = _baseService.Add(entity);

            return Ok(response);
        }

        [HttpPut]
        public virtual IActionResult Put(Dto entity)
        { 
            var response = _baseService.Update(entity);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual IActionResult Delete(int id)
        {
            var entity = _baseService.GetEntity(id);

            var response = _baseService.Delete(entity);

            return Ok(response);
        }
    }
}
