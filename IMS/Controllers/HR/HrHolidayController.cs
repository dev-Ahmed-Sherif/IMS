using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrHolidayController : ControllerBase
    {

        private HrHolidayService _HolidayService;

        public HrHolidayController(HrHolidayService HolidayService)
        {
            _HolidayService = HolidayService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrHolidayVM Holiday)
        {
            var _response = _HolidayService.Add(Holiday);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrHolidayVM Holiday)
        {
            var _response = _HolidayService.Update(Holiday);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _HolidayService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allHoliday = _HolidayService.GetAll();
            return Ok(allHoliday);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Holiday = _HolidayService.GetById(id);
            return Ok(Holiday);
        }

    }
}
