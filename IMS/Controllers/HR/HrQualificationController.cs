using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrQualificationController : ControllerBase
    {

        private HrQualificationService _QualificationService;

        public HrQualificationController(HrQualificationService QualificationService)
        {
            _QualificationService = QualificationService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrQualificationVM ID)
        {
            var _response = _QualificationService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrQualificationVM ID)
        {
            var _response = _QualificationService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _QualificationService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allQualification = _QualificationService.GetAll();
            return Ok(allQualification);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetQualificationById(int ID)
        {
            var Qualification = _QualificationService.GetById(ID);
            return Ok(Qualification);
        }

    }
}
