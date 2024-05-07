using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrEmployeeVacationBalanceController : ControllerBase
    {

        private HrEmployeeVacationBalanceService _EmployeeVacationBalanceService;

        public HrEmployeeVacationBalanceController(HrEmployeeVacationBalanceService EmployeeVacationBalanceService)
        {
            _EmployeeVacationBalanceService = EmployeeVacationBalanceService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrEmployeeVacationBalanceVM ID)
        {
            var _response = _EmployeeVacationBalanceService.Add(ID);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrEmployeeVacationBalanceVM ID)
        {
            var _response = _EmployeeVacationBalanceService.Update(ID);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int ID)
        {
            var _response = _EmployeeVacationBalanceService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allEmployeeVacationBalance = _EmployeeVacationBalanceService.GetAll();
            return Ok(allEmployeeVacationBalance);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int ID)
        {
            var EmployeeVacationBalance = _EmployeeVacationBalanceService.GetById(ID);
            return Ok(EmployeeVacationBalance);
        }

    }
}
