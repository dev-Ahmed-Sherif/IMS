using Business.FI.Account;
using Business.Pro;
using Entities.ViewModels.Pro;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProVendorController : ControllerBase
    {

        private ProVendorService _VendorService;

        public ProVendorController(ProVendorService VendorService)
        {
            _VendorService = VendorService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ProVendorVM Vendor)
        {
            string _response = await _VendorService.Add(Vendor);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProVendorVM Vendor)
        {
            string _response = await _VendorService.Update(Vendor);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _VendorService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allVendor = _VendorService.GetAll();
            return Ok(allVendor);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Vendor = _VendorService.GetById(id);
            return Ok(Vendor);
        }
        [HttpGet("get/By/Name/{Name}")]
        public IActionResult GetVendorByName(string Name)
        {
            var Vendor = _VendorService.GetByName(Name);
            return Ok(Vendor);
        }
        [HttpGet("AutoCode")]
        public IActionResult GetLastNo()
        {
            var _response = _VendorService.GetLastNo();
            return new JsonResult(_response);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] VendorSearchGeneral searchModel)
        {
            var AllSTR_Add_Details = _VendorService.Search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _VendorService.GetAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }

}
