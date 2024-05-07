using Business.STR.Add;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Entities.ViewModels.STR.AddDetails.StrAddDetailsGeneralVM;

namespace IMS.Controllers.STR.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class STRAddDetailsController : ControllerBase
    {
        private StrAddDetailsService _sTR_AddDetailsService;

        public STRAddDetailsController(StrAddDetailsService AddDetailsService)
        {
            _sTR_AddDetailsService = AddDetailsService;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] StrAddWithavgprice add_Details)
        {
            var _response = _sTR_AddDetailsService.Add(add_Details);
            return Ok(_response);
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] StrAddWithavgprice updateDetails)
        {
            var _response = _sTR_AddDetailsService.Update(updateDetails);
            return new JsonResult(_response);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var _response = _sTR_AddDetailsService.Delete(id);
            return new JsonResult(_response);
        }
        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var AllSTR_Add_Details = _sTR_AddDetailsService.GetAll();
            return Ok(AllSTR_Add_Details);
        }
        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var addDetails = _sTR_AddDetailsService.GetById(id);
            return Ok(addDetails);
        }

        [HttpGet("search")]
        public IActionResult Searchadddetail([FromQuery] Entities.ViewModels.STR.AddDetails.searchadd searchModel)
        {
            var Add = _sTR_AddDetailsService.Search(searchModel);
            return Ok(Add);
        }
        // Details
        [HttpGet("get/by/header/{id}")]
        public IActionResult GetByHeader(int id)
        {
            var opening_Stock = _sTR_AddDetailsService.GetByHeader(id);
            return Ok(opening_Stock);
        }

        [HttpGet("get/sum/quantity/{storeid}/{itemid}")]
        public IActionResult GetSumOfQty(int storeid, int itemid)
        {
            var Avgprice = _sTR_AddDetailsService.GetSumOfQty(storeid, itemid);
            return Ok(Avgprice);
        }
        [HttpGet("get/Avg/Price/{FiscalYearid}/{itemid}")]
        public IActionResult GetAvgPrice(int FiscalYearid, int itemid)
        {
            decimal Avgprice =  _sTR_AddDetailsService.GetAvgPrice(FiscalYearid, itemid);
            return Ok(Avgprice);
        }
        [HttpGet("get/new/Avg/Price/{FiscalYearid}/{itemid}/{newprice}")]
        public IActionResult NewAvgPrice(int itemid, decimal newprice, int FiscalYearid)
        {
            decimal Avgprice =  _sTR_AddDetailsService.NewAvgPrice(itemid, newprice, FiscalYearid);
            return Ok(Avgprice);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize, int HeaderId)
        {
            var Pagination = _sTR_AddDetailsService.getAllByPagination(page, pageSize, HeaderId);
            return Ok(Pagination);
        }
        [HttpGet("get/sumadd/quantity/{storeid}/{addtypeid}/{startdate}/{enddate}")]
        public IActionResult GetSumOfQtyaddtype(int storeid, int addtypeid, DateTime startdate, DateTime enddate)
        {
            var (sumOfQty, sumOfTotal) = _sTR_AddDetailsService.GetSumOfQtyaddtype(storeid, addtypeid, startdate, enddate);
            //return Ok(Avgprice);
            //decimal sumOfQty = Avgprice.sumOfQty;
            //decimal sumOfTotal = result.sumOfTotal;

            //// Return an appropriate response
            return Ok(new { sumOfQty, sumOfTotal });
        }
        [HttpGet("get/sumwithdraw/quantity/{storeid}/{WithDrawTypeId}/{startdate}/{enddate}")]
        public IActionResult GetSumOfQtywithdrawtype(int storeid, int WithDrawTypeId, DateTime startdate, DateTime enddate)
        {
            var (sumOfQty, sumOfTotal) = _sTR_AddDetailsService.GetSumOfQtywithdrawtype(storeid, WithDrawTypeId, startdate, enddate);
            //return Ok(Avgprice);
            //decimal sumOfQty = Avgprice.sumOfQty;
            //decimal sumOfTotal = result.sumOfTotal;

            //// Return an appropriate response
            return Ok(new { sumOfQty, sumOfTotal });
        }


    }
}
