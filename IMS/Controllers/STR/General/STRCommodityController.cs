using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRCommodityController : ControllerBase
    {

        private StrCommodityService _commodityService;

        public STRCommodityController(StrCommodityService commodityService)
        {
            _commodityService = commodityService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrCommodityVM commodity)
        {
            var _response = _commodityService.Add(commodity);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] StrCommodityVM commodity)
        {
            var _response = _commodityService.Update(commodity);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _commodityService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allCommodity = _commodityService.GetAll();
            return Ok(allCommodity);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var commodity = _commodityService.GetById(id);
            return Ok(commodity);
        }

        [HttpGet("get/with/grades/{id}")]
        public IActionResult GetWithGrades(int id)
        {
            var _response = _commodityService.GetWithGrades(id);
            return Ok(_response);
        }
        [HttpGet("AutoCode")]
        public IActionResult GetLastNo()
        {
            var _response = _commodityService.GetLastNo();
            return new JsonResult(_response);
        }
    }

}
