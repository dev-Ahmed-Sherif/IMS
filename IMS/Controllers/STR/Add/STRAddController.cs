using Business.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers.STR.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRAddController : ControllerBase
    {
        private StrAddService _sTR_AddService;

        public STRAddController(StrAddService AddService)
        {
            _sTR_AddService = AddService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] StrAddVM add)
        {
            string _response = await _sTR_AddService.Add(add);
            return new JsonResult(_response);
        }

        [HttpPost("AddFromStore")]
        public IActionResult AddFromStore([FromBody] AddFromStoreVM id)
        {
            var _response = _sTR_AddService.AddFromStore(id);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] StrAddVM update)
        {
            string _response = await _sTR_AddService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _sTR_AddService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _sTR_AddService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _sTR_AddService.GetById(id);
            return Ok(add);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] Entities.ViewModels.STR.AddDetails.searchadd searchModel)
        {
            var Add = _sTR_AddService.Search(searchModel);
            return Ok(Add);
        }
        [HttpGet("get/By/Employee/Stores/{employeeId}")]
        public IActionResult GetByEmployeeStores(int employeeId, int page, int pageSize, int fiscalYearId)
        {
            var add = _sTR_AddService.GetByEmployeeStores(employeeId, page, pageSize, fiscalYearId);
            return Ok(add);
        }
        [HttpGet("get/AutoNo")]
        public IActionResult GetLastNo(int StoreId, int FiscalYearId)
        {
            var AutoNo = _sTR_AddService.GetLastNo(StoreId, FiscalYearId);
            return Ok(AutoNo);
        }

        [HttpGet("get/Report")]

        public IActionResult Get([FromQuery] reportAddsearch searchModel)
        {
            var reportFileByString = _sTR_AddService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

    }

}
