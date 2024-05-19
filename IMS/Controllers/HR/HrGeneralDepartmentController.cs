using Business.HR;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrGeneralDepartmentController : ControllerBase
    {
        private GeneralDepartmentService _GeneralDepartmentService;

        public HrGeneralDepartmentController(GeneralDepartmentService GDepService)
        {
            _GeneralDepartmentService = GDepService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] GeneralDepartmentgeneralVM Gdep)
        {
            var _response = _GeneralDepartmentService.Add(Gdep);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] GeneralDepartmentVM Gdep)
        {
            var _response = _GeneralDepartmentService.Update(Gdep);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _GeneralDepartmentService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allGDep = _GeneralDepartmentService.GetAll();
            return Ok(allGDep);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Gdep = _GeneralDepartmentService.GetById(id);
            return Ok(Gdep);
        }

    }
}
