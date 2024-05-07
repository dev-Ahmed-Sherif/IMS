using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;


namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]

    public class HrHolidayScheduleController : ControllerBase
    {

        private HrHolidayScheduleService _HolidayScheduleService;

        public HrHolidayScheduleController(HrHolidayScheduleService HolidayScheduleService)
        {
            _HolidayScheduleService = HolidayScheduleService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrHolidayScheduleVM HolidaySchedule)
        {
            var _response = _HolidayScheduleService.Add(HolidaySchedule);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrHolidayScheduleVM HolidaySchedule)
        {
            var _response = _HolidayScheduleService.Update(HolidaySchedule);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _HolidayScheduleService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allHolidaySchedule = _HolidayScheduleService.GetAll();
            return Ok(allHolidaySchedule);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var HolidaySchedule = _HolidayScheduleService.GetById(id);
            return Ok(HolidaySchedule);
        }

    }
}
