using Business.FI.Entry;
using Entities.ViewModels.FI.Entry;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers.FI.Entry
{
    [Route("api/[controller]")]
    [ApiController]
    public class FIEntryController : ControllerBase
    {
        private FiEntryService _item;

        public FIEntryController(FiEntryService FI_EntryService)
        {
            _item = FI_EntryService;
        }

        [HttpPost("Add")]
        public IActionResult AddItem([FromBody] FiEntryGeneralVM entry)
        {
            var _response = _item.Add(entry);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult UpdateItem([FromBody] FiEntryVM entry)
        {
            var _response = _item.Update(entry);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var _response = _item.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllItem()
        {
            var allItems = _item.GetAll();
            return Ok(allItems);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var CostCenter = await _item.GetById(id);
            return Ok(CostCenter);
        }
        [HttpGet("search")]
        public IActionResult Searchadd([FromQuery] searchFiEntry searchModel)
        {
            var Add = _item.Search(searchModel);
            return Ok(Add);
        }
        [HttpGet("get/Last/index")]
        public IActionResult GetLastIndex([FromQuery] int? indexSize = null)
        {
            var allItems = _item.GetLastIndex(indexSize);
            return Ok(allItems);
        }
        [HttpGet("get/pagnation")]
        public IActionResult GetEntry(int page, int pageSize, int YearID)
        {
            var allItems = _item.GetPagination(page, pageSize, YearID);
            return Ok(allItems);
        }
        [HttpGet("get/search/pagnation")]
        public IActionResult SearchPagination([FromQuery] searchFiEntry searchModel, int page, int pageSize)
        {
            var allItems = _item.SearchPagination(searchModel ,page, pageSize);
            return Ok(allItems);
        }
        [HttpGet("get/Report")]
        public async Task<IActionResult> Get([FromQuery] ReportFiEntry searchModel, int HeaderId)
        {

            var reportFileByString = await _item.GenerateReportAsync(searchModel.reportName, searchModel.reportType, searchModel, HeaderId);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }
        [HttpGet("AutoCode")]

        public IActionResult AutoNo()
        {
            var AutoNo = _item.GetLastNo();
            return Ok(AutoNo);
        }



    }
}
