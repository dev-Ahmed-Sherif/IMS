using Business.HR;
using Business.TR.Excuted;
using Entities.ViewModels.HR;
using Entities.ViewModels.TR.Course;
using Entities.ViewModels.TR.Excuted;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.TR.Excuted
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrExcutedController : ControllerBase
    {

        private TrExcutedService _TrExcutedService;

        public TrExcutedController(TrExcutedService TrExcutedService)
        {
            _TrExcutedService = TrExcutedService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrExcutedGeneralVM add)
        {
            var _response = _TrExcutedService.Add(add);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TrExcutedVM update)
        {
            var _response = _TrExcutedService.Update(update);
            return new JsonResult(_response);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _TrExcutedService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _TrExcutedService.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _TrExcutedService.GetById(id);
            return Ok(add);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] TrExcutedSearch searchModel)
        {
            var TrExcuted = _TrExcutedService.Search(searchModel);
            return Ok(TrExcuted);
        }
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] TrExcutedReport searchModel)
        {

            var reportFileByString = _TrExcutedService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }


    }
}
