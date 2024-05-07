using Business.PR;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrGroupPrivilegesController : ControllerBase
    {
        // we need  an object of the service to work we wlii call it (_PrivilegessService)
        private PrGroupPrivilegesService _groupPrivilegessService;

        // Contructor of the class needs from user to fill the service object (_PrivilegessService)
        public PrGroupPrivilegesController(PrGroupPrivilegesService groupPrivilegessService)
        {
            _groupPrivilegessService = groupPrivilegessService;
        }

        [HttpPost("add")]
        public IActionResult AddGroup_Privileges([FromBody] PrGroupPrivilegesVM Group_Privileges)
        {
            var _response = _groupPrivilegessService.Add(Group_Privileges);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult UpdateGroup_PrivilegesById([FromBody] PrGroupPrivilegesVM Group_Privileges)
        {
            var _response = _groupPrivilegessService.Update(Group_Privileges);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGroup_Privileges(int id)
        {
            var _response = _groupPrivilegessService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllGroup_Privilegess()
        {
            var allGroupPrivilegess = _groupPrivilegessService.GetAll();
            return Ok(allGroupPrivilegess);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetGroup_PrivilegesById(int id)
        {
            var Group_Privileges = _groupPrivilegessService.GetById(id);
            return Ok(Group_Privileges);
        }

    }
}
