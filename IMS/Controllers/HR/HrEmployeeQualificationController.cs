using Business.HR;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace IMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class HrEmployeeQualificationController : ControllerBase
    {

        private HrEmployeeQualificationService _EmployeeQualificationService;

        public HrEmployeeQualificationController(HrEmployeeQualificationService EmployeeQualificationService)
        {
            _EmployeeQualificationService = EmployeeQualificationService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeQualificationVM EmployeeQualification)
        {
            var _response = _EmployeeQualificationService.Add(EmployeeQualification);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeQualificationVM EmployeeQualification)
        {
            var _response = _EmployeeQualificationService.Update(EmployeeQualification);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _EmployeeQualificationService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeQualification = _EmployeeQualificationService.GetAll();
            return Ok(allEmployeeQualification);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var EmployeeQualification = _EmployeeQualificationService.GetById(id);
            return Ok(EmployeeQualification);
        }

    }
}
