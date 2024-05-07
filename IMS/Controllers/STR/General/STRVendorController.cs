using Business.STR.General;
using Entities.ViewModels.STR.General;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRVendorController : ControllerBase
    {
        private StrVendorService _vendor;

        public STRVendorController(StrVendorService StrVendorService)
        {
            _vendor = StrVendorService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrVendorGeneralVM vendor)
        {
            var _response = _vendor.Add(vendor);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] StrVendorVM vendor)
        {
            var _response = _vendor.Update(vendor);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _vendor.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItems = _vendor.GetAll();
            return Ok(allItems);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var CostCenter = _vendor.GetById(id);
            return Ok(CostCenter);
        }
        [HttpGet("get/By/Name/{Name}")]
        public IActionResult GetByName(string Name)
        {
            var allItems = _vendor.GetByName(Name);
            return Ok(allItems);
        }
    }
}
