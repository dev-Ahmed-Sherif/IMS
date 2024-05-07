

using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]

    public class HrFinancialDegreeSalaryController : ControllerBase
    {

        private HrFinancialDegreeSalaryService _FinancialDegreeSalaryService;

        public HrFinancialDegreeSalaryController(HrFinancialDegreeSalaryService FinancialDegreeSalaryService)
        {
            _FinancialDegreeSalaryService = FinancialDegreeSalaryService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrFinancialDegreeSalaryVM FinancialDegreeSalary)
        {
            var _response = _FinancialDegreeSalaryService.Add(FinancialDegreeSalary);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrFinancialDegreeSalaryVM FinancialDegreeSalary)
        {
            var _response = _FinancialDegreeSalaryService.Update(FinancialDegreeSalary);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _FinancialDegreeSalaryService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allFinancialDegreeSalary = _FinancialDegreeSalaryService.GetAll();
            return Ok(allFinancialDegreeSalary);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var FinancialDegreeSalary = _FinancialDegreeSalaryService.GetById(id);
            return Ok(FinancialDegreeSalary);
        }


    }
}
