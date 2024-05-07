using Business.HR;
using Entities.ViewModels.HR;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.HR
{

    [Route("api/[controller]")]
    [ApiController]
    public class HrFinancialDegreeController : ControllerBase
    {

        private HrFinancialDegreeService _FinancialDegreeService;

        public HrFinancialDegreeController(HrFinancialDegreeService FinancialDegreeService)
        {
            _FinancialDegreeService = FinancialDegreeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] HrFinancialDegreeVM FinancialDegree)
        {
            var _response = _FinancialDegreeService.Add(FinancialDegree);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] HrFinancialDegreeVM FinancialDegree)
        {
            var _response = _FinancialDegreeService.Update(FinancialDegree);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _FinancialDegreeService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allFinancialDegree = _FinancialDegreeService.GetAll();
            return Ok(allFinancialDegree);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var FinancialDegree = _FinancialDegreeService.GetById(id);
            return Ok(FinancialDegree);
        }

    }
}
