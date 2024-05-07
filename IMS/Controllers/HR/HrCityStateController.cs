using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrCityStateController : ControllerBase
    {

        private HrCityStateService _CityStateService;

        public HrCityStateController(HrCityStateService CityStateService)
        {
            _CityStateService = CityStateService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrCityStateVM CityState)
        {
            var _response = _CityStateService.Add(CityState);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrCityStateVM CityState)
        {
            var _response = _CityStateService.Update(CityState);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _CityStateService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allCityState = _CityStateService.GetAll();
            return Ok(allCityState);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var CityState = _CityStateService.GetById(id);
            return Ok(CityState);
        }

    }
}
