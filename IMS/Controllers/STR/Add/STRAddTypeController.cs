using Business.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRAddTypeController : ControllerBase
    {
        private AddTypeService _typeService;
        public STRAddTypeController(AddTypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpPost("Add")]
        public IActionResult AddType([FromBody] StrAddTypeGeneralVM type)
        {
            var _response = _typeService.Add(type);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateType([FromBody] StrAddTypeVM type)
        {
            var _response = _typeService.Update(type);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTypeById(int id)
        {
            var _response = _typeService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allType = _typeService.GetAll();
            return Ok(allType);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var type = _typeService.GetById(id);
            return Ok(type);
        }

    }
}
