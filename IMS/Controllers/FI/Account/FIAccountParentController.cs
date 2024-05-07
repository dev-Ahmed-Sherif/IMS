using Business.FI.Account;
using Entities.ViewModels.FI.Account;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.FI.Account
{
    [Route("api/[controller]")]
    [ApiController]

    public class FIAccountParentController : ControllerBase
    {
        private FiAccountParentService _FiAccountParentService;
        public FIAccountParentController(FiAccountParentService FiAccountParentService)
        {
            _FiAccountParentService = FiAccountParentService;
        }

        [HttpPost("Add")]
        public IActionResult AddAccount([FromBody] FiAccountParentVM AccountParent)
        {
            var _response = _FiAccountParentService.Add(AccountParent);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult UpdateAccountParent([FromBody] FiAccountParentVM Account)
        {
            var _response = _FiAccountParentService.Update(Account);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAccountParent(int ID)
        {
            var _response = _FiAccountParentService.Delete(ID);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAllAccountParent()
        {
            var allAccount = _FiAccountParentService.GetAll();
            return Ok(allAccount);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetAccountParentById(int id)
        {
            var Account = _FiAccountParentService.GetById(id);
            return Ok(Account);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _FiAccountParentService.GetAllByPagination(page, pageSize);
            return Ok(Pagination);
        }
    }
}
