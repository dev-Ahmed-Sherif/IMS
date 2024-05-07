using Business.PR;
using Entities.ViewModels.PR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class PRModuleController : ControllerBase
    {
        // we need  an object of the service to work we wlii call it (_ModulesService)
        private PrModuleService _ModulesService;

        // Contructor of the class needs from user to fill the service object (_ModulesService)
        public PRModuleController(PrModuleService ModulesService)
        {
            _ModulesService = ModulesService;
        }
        [HttpPost("add")]
        public IActionResult AddModule([FromBody] PrModuleVM Module)
        {
            var _response = _ModulesService.Add(Module);
            return new JsonResult(_response);
        }


        [HttpPut("update")]
        public IActionResult UpdateModule([FromBody] PrModuleVM Module)
        {
            var _response = _ModulesService.Update(Module);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteModule(int id)
        {
            var _response = _ModulesService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllModules()
        {
            var allModules = _ModulesService.GetAll();
            return Ok(allModules);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetModuleById(int id)
        {
            var Module = _ModulesService.GetById(id);
            return Ok(Module);
        }


    }
}
