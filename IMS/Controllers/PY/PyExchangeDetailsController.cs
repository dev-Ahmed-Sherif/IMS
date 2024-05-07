using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PY
{

    [Route("api/[controller]")]
    [ApiController]
    public class PyExchangeDetailsController : ControllerBase
    {

        private PyExchangeDetailsService _ExchangeDetailsService;

        public PyExchangeDetailsController(PyExchangeDetailsService ExchangeDetailsService)
        {
            _ExchangeDetailsService = ExchangeDetailsService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PyExchangeDetailsVM ExchangeDetails)
        {
            var _response = _ExchangeDetailsService.Add(ExchangeDetails);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyExchangeDetailsVM ExchangeDetails)
        {
            var _response = _ExchangeDetailsService.Update(ExchangeDetails);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _ExchangeDetailsService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allExchangeDetails = _ExchangeDetailsService.GetAll();
            return Ok(allExchangeDetails);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var ExchangeDetails = _ExchangeDetailsService.GetById(id);
            return Ok(ExchangeDetails);
        }
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var ExchangeDetails = _ExchangeDetailsService.GetByHeader(id);
            return Ok(ExchangeDetails);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------

        [HttpGet("get/by/pagination")]
        public IActionResult GetAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Account = _ExchangeDetailsService.GetAllByPagination(page, pageSize, HeaderId);
            return Ok(Account);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] search searchModel)
        {
            var AllSTR_Add_Details = _ExchangeDetailsService.Search(searchModel);
            //DateTime? requiredDate = searchModel.Date;
            return Ok(AllSTR_Add_Details);
        }

    }
}
