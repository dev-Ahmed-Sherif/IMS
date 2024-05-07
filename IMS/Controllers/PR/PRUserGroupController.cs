using Business.PR;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PRUserGroupController : ControllerBase
    {
        // we need  an object of the service to work we wlii call it (_RolesService)
        private PrUserGroupService _userGroupsService;

        // Contructor of the class needs from user to fill the service object (_RolesService)
        public PRUserGroupController(PrUserGroupService userGroupsService)
        {
            _userGroupsService = userGroupsService;
        }
        [HttpPost("add")]
        public IActionResult AddUser_Group([FromBody] PrUserGroupVM User_Group)
        {
            var _response = _userGroupsService.Add(User_Group);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult UpdateUser_group([FromBody] PrUserGroupVM User_Group)
        {
            var _response = _userGroupsService.Update(User_Group);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser_Group(int id)
        {
            var _response = _userGroupsService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAllUserGroups()
        {
            var allUserGroups = _userGroupsService.GetAll();
            return Ok(allUserGroups);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetUser_GroupById(int id)
        {
            var User_Group = _userGroupsService.GetById(id);
            return Ok(User_Group);
        }
        [HttpGet("get/User/Group/{Userid}")]
        public IActionResult GetByUser(int Userid)
        {
            var store = _userGroupsService.GetByUser(Userid);
            return Ok(store);
        }
    }
}
