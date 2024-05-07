using Business.HR;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeDisciplinaryController : ControllerBase
    {

        private HrEmployeeDisciplinaryService _EmployeeDisciplinaryService;

        public HrEmployeeDisciplinaryController(HrEmployeeDisciplinaryService EmployeeDisciplinaryService)
        {
            _EmployeeDisciplinaryService = EmployeeDisciplinaryService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            var _response = _EmployeeDisciplinaryService.Add(EmployeeDisciplinary);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeDisciplinaryVM EmployeeDisciplinary)
        {
            var _response = _EmployeeDisciplinaryService.Update(EmployeeDisciplinary);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _EmployeeDisciplinaryService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeDisciplinary = _EmployeeDisciplinaryService.GetAll();
            return Ok(allEmployeeDisciplinary);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeDisciplinary = _EmployeeDisciplinaryService.GetById(id);
            return Ok(EmployeeDisciplinary);
        }

    }
}
