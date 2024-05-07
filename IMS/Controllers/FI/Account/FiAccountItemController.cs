using Business.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.FI.Account
{
    [Route("api/[controller]")]
    [ApiController]

    public class FiAccountItemController : ControllerBase
    {
        private FiAccountItemService _FiAccountItemService;
        public FiAccountItemController(FiAccountItemService FiAccountItemService)
        {
            _FiAccountItemService = FiAccountItemService;
        }

        [HttpPost("Add")]
        public IActionResult AddAccount([FromBody] FiAccountItemVM AccountItem)
        {
            var _response = _FiAccountItemService.Add(AccountItem);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateAccountItem([FromBody] FiAccountItemVM Account)
        {
            var _response = _FiAccountItemService.Update(Account);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAccountItem(int id)
        {
            var _response = _FiAccountItemService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllAccountItem()
        {
            var allAccount = _FiAccountItemService.GetAll();
            return Ok(allAccount);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetAccountItemById(int id)
        {
            var Account = _FiAccountItemService.GetById(id);
            return Ok(Account);
        }
        [HttpGet("get/By/Name/{Name}")]
        public IActionResult getByName(string Name)
        {
            var Account = _FiAccountItemService.GetByName(Name);
            return Ok(Account);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _FiAccountItemService.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
