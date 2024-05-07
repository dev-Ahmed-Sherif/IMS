using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRFiscalYearController : ControllerBase
    {
        private StrFiscalYearServices _StrFiscalYearServices;
        public STRFiscalYearController(StrFiscalYearServices yearService)
        {
            _StrFiscalYearServices = yearService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrFiscalYearGeneralVM year)
        {
            var _response = _StrFiscalYearServices.Add(year);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] StrFiscalYearVM year)
        {
            var _response = _StrFiscalYearServices.Update(year);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _StrFiscalYearServices.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allReceipt = _StrFiscalYearServices.GetAll();
            return Ok(allReceipt);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var receipt = _StrFiscalYearServices.GetById(id);
            return Ok(receipt);
        }
        [HttpGet("get/Last/fisical/year")]
        public IActionResult GetLast()
        {

            var allReceipt = _StrFiscalYearServices.GetLast();
            return Ok(allReceipt);
        }

    }
}
