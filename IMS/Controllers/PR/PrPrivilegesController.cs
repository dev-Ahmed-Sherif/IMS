using Business.PR;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrPrivilegesController : ControllerBase
    {
        private PrPrivilegesService _groupsService;

        public PrPrivilegesController(PrPrivilegesService groupsService)
        {
            _groupsService = groupsService;
        }

        [HttpPost("Add")]
        public IActionResult AddGroup([FromBody] PrPrivilegesVM group)
        {
            var _response = _groupsService.Add(group);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateGroup([FromBody] PrPrivilegesVM group)
        {
            var _response = _groupsService.Update(group);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGroup(int id)
        {
            var _response = _groupsService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllGroups()
        {
            var allGroups = _groupsService.GetAll();
            return Ok(allGroups);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetGroupById(int id)
        {
            var group = _groupsService.GetById(id);
            return Ok(group);
        }

    }
}
