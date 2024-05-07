using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]

    public class HrVacationController : ControllerBase
    {

        private HrVacationService _VacationService;

        public HrVacationController(HrVacationService VacationService)
        {
            _VacationService = VacationService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrVacationVM ID)
        {
            var _response = _VacationService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrVacationVM ID)
        {
            var _response = _VacationService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _VacationService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allVacation = _VacationService.GetAll();
            return Ok(allVacation);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var Vacation = _VacationService.GetById(ID);
            return Ok(Vacation);
        }

    }
}
