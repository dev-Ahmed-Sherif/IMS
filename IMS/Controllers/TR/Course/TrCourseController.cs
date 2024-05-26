using Business.HR;
using Business.TR.Course;
using Entities.ViewModels.HR;
using Entities.ViewModels.TR.Course;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace IMS.Controllers.TR.Course
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrCourseController : ControllerBase
    {
        private TrCourseService _Service;

        public TrCourseController(TrCourseService AddCourse)
        {
            _Service = AddCourse;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] TrCourseVM add)
        {
            var _response = _Service.Add(add);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] TrCourseVM update)
        {
            var _response = _Service.Update(update);
            return new JsonResult(_response);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Service.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add = _Service.GetAll();
            return Ok(AllSTR_Add);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var add = _Service.GetById(id);
            return Ok(add);
        }

        [HttpGet("Search")]
        public IActionResult Search(TrCourseSearch searchModel)
        {
            var search = _Service.Search(searchModel);
            return Ok(search);
        }

        //[HttpGet("get/Report")]
        //public IActionResult Get([FromQuery] TrCourseReport searchModel)
        //{

        //    var reportFileByString = _Service.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
        //    return File(reportFileByString, MediaTypeNames.Application.Pdf, getReportDetails(searchModel.reportName, searchModel.reportType));
        //}

        //private string getReportDetails(string reportName, string reportType)
        //{
        //    var outputFileName = reportName + ".pdf";

        //    switch (reportType.ToUpper())
        //    {
        //        default:
        //        case "PDF":
        //            outputFileName = reportName + ".pdf"; break;
        //        case "XLS":
        //            outputFileName = reportName + ".xls"; break;
        //        case "WORD":
        //            outputFileName = reportName + ".doc"; break;
        //    }

        //    return outputFileName;
        //}
        [HttpGet("get/Report")]
        public IActionResult Get([FromQuery] TrCourseReport searchModel)
        {

            var reportFileByString = _Service.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }


        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Exchange = _Service.getAllByPagination(page, pageSize);
            return Ok(Exchange);
        }

    }
}
