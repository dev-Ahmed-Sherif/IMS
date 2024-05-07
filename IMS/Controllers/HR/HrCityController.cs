using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrCityController : ControllerBase
    {

        private HrCityService _CityService;

        public HrCityController(HrCityService CityService)
        {
            _CityService = CityService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrCityVM City)
        {
            var _response = _CityService.Add(City);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrCityVM City)
        {
            var _response = _CityService.Update(City);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _CityService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allCity = _CityService.GetAll();
            return Ok(allCity);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var City = _CityService.GetById(id);
            return Ok(City);
        }

    }
}
