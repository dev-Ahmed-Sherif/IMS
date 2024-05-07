using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Controllers.PY
{

    [Route("api/[controller]")]
    [ApiController]
    public class PyExchangeController : ControllerBase
    {

        private PyExchangeService _ExchangeService;

        public PyExchangeController(PyExchangeService ExchangeService)
        {
            _ExchangeService = ExchangeService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PyExchangeVM Exchange)
        {
            var _response = _ExchangeService.Add(Exchange);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyExchangeVM Exchange)
        {
            var _response = _ExchangeService.Update(Exchange);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _ExchangeService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allExchange = _ExchangeService.GetAll();
            return Ok(allExchange);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Exchange = _ExchangeService.GetById(id);
            return Ok(Exchange);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Exchange = _ExchangeService.getAllByPagination(page, pageSize);
            return Ok(Exchange);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] search searchModel)
        {
            var AllSTR_Add_Details = _ExchangeService.Search(searchModel);
            //DateTime? requiredDate = searchModel.Date;
            return Ok(AllSTR_Add_Details);
        }

    }
}
