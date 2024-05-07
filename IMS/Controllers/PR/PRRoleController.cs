using Business.PR;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PRRoleController : ControllerBase
    {
        // we need  an object of the service to work we wlii call it (_RolesService)
        private PrRoleService _rolesService;

        // Contructor of the class needs from user to fill the service object (_RolesService)
        public PRRoleController(PrRoleService rolesService)
        {
            _rolesService = rolesService;
        }
        [HttpPost("add")]
        public IActionResult AddRole([FromBody] PrRoleVM Role)
        {
            var _response = _rolesService.Add(Role);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult UpdateRole([FromBody] PrRoleVM Role)
        {
            var _response = _rolesService.Update(Role);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRole(int id)
        {
            var _response = _rolesService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllRoles()
        {
            var allRoles = _rolesService.GetAll();
            return Ok(allRoles);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetRoleById(int id)
        {
            var Role = _rolesService.GetById(id);
            return Ok(Role);
        }


    }
}
