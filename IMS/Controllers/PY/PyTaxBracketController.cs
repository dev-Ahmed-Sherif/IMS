using Business.PY;
using Entities.ViewModels.PY;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers.PY
{

    [Route("api/[controller]")]
    [ApiController]

    public class PyTaxBracketController : ControllerBase
    {

        private PyTaxBracketService _TaxBracketService;

        public PyTaxBracketController(PyTaxBracketService TaxBracketService)
        {
            _TaxBracketService = TaxBracketService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] PyTaxBracketVM TaxBracket)
        {
            var _response = _TaxBracketService.Add(TaxBracket);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] PyTaxBracketVM TaxBracket)
        {
            var _response = _TaxBracketService.Update(TaxBracket);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _TaxBracketService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allTaxBracket = _TaxBracketService.GetAll();
            return Ok(allTaxBracket);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var TaxBracket = _TaxBracketService.GetById(id);
            return Ok(TaxBracket);
        }

        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Item = _TaxBracketService.GetAllByPagination(page, pageSize);
            return Ok(Item);
        }

    }
}
