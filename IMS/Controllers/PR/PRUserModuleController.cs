using Business.PR;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PRUserModuleController : ControllerBase
    {
        // we need  an object of the service to work we wlii call it (_RolesService)
        private PrUserModuleService _userModulesService;

        // Contructor of the class needs from user to fill the service object (_RolesService)
        public PRUserModuleController(PrUserModuleService userModulesService)
        {
            _userModulesService = userModulesService;
        }
        [HttpPost("add")]
        public IActionResult AddUser_Module([FromBody] PrUserModuleVM User_Module)
        {
            var _response = _userModulesService.Add(User_Module);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult UpdateUser_Module([FromBody] PrUserModuleVM User_Module)
        {
            var _response = _userModulesService.Update(User_Module);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser_Module(int id)
        {
            var _response = _userModulesService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAllUserModules()
        {
            var allUserModules = _userModulesService.GetAll();
            return Ok(allUserModules);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetUser_ModuleById(int id)
        {
            var User_Module = _userModulesService.GetById(id);
            return Ok(User_Module);
        }

    }
}
