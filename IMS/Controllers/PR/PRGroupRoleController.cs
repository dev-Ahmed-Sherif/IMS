using Business.PR;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]

    public class PRGroupRoleController : ControllerBase
    {
        // we need  an object of the service to work we wlii call it (_RolesService)
        private PrGroupRoleService _groupRolesService;

        // Contructor of the class needs from user to fill the service object (_RolesService)
        public PRGroupRoleController(PrGroupRoleService groupRolesService)
        {
            _groupRolesService = groupRolesService;
        }

        [HttpPost("add")]
        public IActionResult AddGroup_Role([FromBody] PrGroupRoleVM Group_Role)
        {
            var _response = _groupRolesService.Add(Group_Role);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult UpdateGroup_RoleById([FromBody] PrGroupRoleVM Group_Role)
        {
            var _response = _groupRolesService.Update(Group_Role);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteGroup_Role(int id)
        {
            var _response = _groupRolesService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllGroup_Roles()
        {
            var allGroupRoles = _groupRolesService.GetAll();
            return Ok(allGroupRoles);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetGroup_RoleById(int id)
        {
            var Group_Role = _groupRolesService.GetById(id);
            return Ok(Group_Role);
        }
        [HttpGet("get/PRGroupRole/get/by/header/{GroupId}")]
        public IActionResult GetByGroup(int GroupId)
        {
            var store = _groupRolesService.GetByGroup(GroupId);
            return Ok(store);
        }

    }
}
