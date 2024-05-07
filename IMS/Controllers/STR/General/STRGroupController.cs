using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRGroupController : ControllerBase
    {

        private StrGroupService _groupsService;

        public STRGroupController(StrGroupService groupsService)
        {
            _groupsService = groupsService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrGroupVM group)
        {
            var _response = _groupsService.Add(group);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrGroupVM group)
        {
            var _response = _groupsService.Update(group);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _groupsService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allGroups = _groupsService.GetAll();
            return Ok(allGroups);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var group = _groupsService.GetById(id);
            return Ok(group);
        }
        [HttpGet("AutoCode")]
        public IActionResult GetLastNo(int PlatoonId)
        {
            var _response = _groupsService.GetLastNo(PlatoonId);
            return new JsonResult(_response);
        }

    }

}
