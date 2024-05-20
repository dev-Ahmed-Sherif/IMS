using Business.HR;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrDepartmentController : ControllerBase
    {
        private DepartmentService _DepartmentService;

        public HrDepartmentController(DepartmentService DepService)
        {
            _DepartmentService = DepService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] DepartmentGeneralVM dep)
        {
            var _response = _DepartmentService.Add(dep);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] DepartmentVM dep)
        {
            var _response = _DepartmentService.Update(dep);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _DepartmentService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allDep = _DepartmentService.GetAll();
            return Ok(allDep);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var dep = _DepartmentService.GetById(id);
            return Ok(dep);
        }
    }
}
