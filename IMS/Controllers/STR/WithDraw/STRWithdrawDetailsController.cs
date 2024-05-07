using Business.STR.WithDraw;
using Entities.ViewModels.STR.WithDraw;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IMS.Controllers.STR.WithDraw
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRWithdrawDetailsController : ControllerBase
    {
        private StrWithDrawDetailsService _Withdraw_DetailsService;
        public STRWithdrawDetailsController(StrWithDrawDetailsService STR_Withdraw_DetailsService)
        {
            _Withdraw_DetailsService = STR_Withdraw_DetailsService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] StrWithDrawDetailsVM withdrawdetails)
        {
            string _response = await _Withdraw_DetailsService.Add(withdrawdetails);
            return new JsonResult(_response);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] StrWithDrawDetailsVM group)
        {
            var _response = _Withdraw_DetailsService.Update(group);
            return new JsonResult(_response);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _Withdraw_DetailsService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allItems = _Withdraw_DetailsService.GetAll();
            return Ok(allItems);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var item = _Withdraw_DetailsService.GetById(id);
            return Ok(item);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var opening_Stock = _Withdraw_DetailsService.GetByHeader(id);
            return Ok(opening_Stock);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] searchwithdraw searchModel)
        {
            var AllSTR_Add_Details = _Withdraw_DetailsService.Search(searchModel);
            return Ok(AllSTR_Add_Details);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Pagination = _Withdraw_DetailsService.getAllByPagination(page, pageSize, HeaderId);
            return Ok(Pagination);
        }
    }
}
