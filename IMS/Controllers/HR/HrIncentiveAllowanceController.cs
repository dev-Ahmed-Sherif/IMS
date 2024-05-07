using Business.HR;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HrIncentiveAllowanceController : ControllerBase
    {

        private HrIncentiveAllowanceService _IncentiveAllowanceService;

        public HrIncentiveAllowanceController(HrIncentiveAllowanceService IncentiveAllowanceService)
        {
            _IncentiveAllowanceService = IncentiveAllowanceService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrIncentiveAllowanceVM IncentiveAllowance)
        {
            var _response = _IncentiveAllowanceService.Add(IncentiveAllowance);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrIncentiveAllowanceVM IncentiveAllowance)
        {
            var _response = _IncentiveAllowanceService.Update(IncentiveAllowance);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _IncentiveAllowanceService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allIncentiveAllowance = _IncentiveAllowanceService.GetAll();
            return Ok(allIncentiveAllowance);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var IncentiveAllowance = _IncentiveAllowanceService.GetById(id);
            return Ok(IncentiveAllowance);
        }

    }
}
