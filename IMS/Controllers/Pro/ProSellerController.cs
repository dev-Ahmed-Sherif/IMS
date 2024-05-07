using Business.Pro;
using Entities.ViewModels.Pro;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.Pro
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProSellerController : ControllerBase
    {

        private ProSellerService _sellerService;

        public ProSellerController(ProSellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] ProSellerVM seller)
        {
            var _response = _sellerService.Add(seller);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] ProSellerVM seller)
        {
            var _response = _sellerService.Update(seller);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _sellerService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allSeller = _sellerService.GetAll();
            return Ok(allSeller);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var seller = _sellerService.GetById(id);
            return Ok(seller);
        }
        [HttpGet("get/By/Name/{Name}")]
        public IActionResult GetSellerByName(string Name)
        {
            var seller = _sellerService.GetByName(Name);
            return Ok(seller);
        }
        [HttpGet("AutoCode")]
        public IActionResult GetLastNo()
        {
            var _response = _sellerService.GetLastNo();
            return new JsonResult(_response);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] SellerSearchGeneral searchModel)
        {
            var AllSTR_Add_Details = _sellerService.Search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
    }

}
