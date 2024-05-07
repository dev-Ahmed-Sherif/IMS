using Business.STR.Add;
using Entities.ViewModels.STR.AddDetails;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.STR.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRAddReceiptController : ControllerBase
    {
        private WithDrawTypeService _receiptService;
        public STRAddReceiptController(WithDrawTypeService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrWithDrawTypeGeneralVM receipt)
        {
            var _response = _receiptService.Add(receipt);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] StrWithDrawTypeVM receipt)
        {
            var _response = _receiptService.Update(receipt);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _receiptService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allReceipt = _receiptService.GetAll();
            return Ok(allReceipt);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var receipt = _receiptService.GetById(id);
            return Ok(receipt);
        }


    }
}
