using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrSpecializationController : ControllerBase
    {

        private HrSpecializationService _SpecializationService;

        public HrSpecializationController(HrSpecializationService SpecializationService)
        {
            _SpecializationService = SpecializationService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrSpecializationVM ID)
        {
            var _response = _SpecializationService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrSpecializationVM ID)
        {
            var _response = _SpecializationService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _SpecializationService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allSpecialization = _SpecializationService.GetAll();
            return Ok(allSpecialization);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var Specialization = _SpecializationService.GetById(ID);
            return Ok(Specialization);
        }

    }
}
