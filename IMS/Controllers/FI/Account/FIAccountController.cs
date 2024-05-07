using Business.FI.Account;
using Entities.ReportViewModels;
using Entities.ViewModels.FI.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IMS.Controllers.FI.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class FIAccountController : ControllerBase
    {
        private FiAccountService _FiAccountService;

        public FIAccountController(FiAccountService FiAccountService)
        {
            _FiAccountService = FiAccountService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] FiAccountVM Account)
        {
            var _response = _FiAccountService.Add(Account);
            return new JsonResult(_response);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] FiAccountVM Account)
        {
            var _response = _FiAccountService.Update(Account);
            return new JsonResult(_response);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Update(int id)
        {
            var _response = _FiAccountService.Delete(id);
            return new JsonResult(_response);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var allAccount = _FiAccountService.GetAll();
            return Ok(allAccount);
        }
        //-----------------------------------------------
        // GET Pagenation { Data with ( page , pagesize)} 
        //-----------------------------------------------
        [HttpGet("get/by/pagination")]
        public IActionResult getAllByPagination(int page, int pageSize)
        {
            var Pagination = _FiAccountService.getAllByPagination(page, pageSize);
            return Ok(Pagination);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            var Account = _FiAccountService.GetById(id);
            return Ok(Account);
        }
        [HttpGet("get/By/Name/{Name}")]
        public IActionResult GetByName(string Name)
        {
            var Account = _FiAccountService.GetByName(Name);
            return Ok(Account);
        }
        [HttpGet("get/data/by/Code/{code}/{startDate}/{endDate}")]
        public IActionResult GetDataByCode(string code, DateTime startDate, DateTime endDate)
        {
            var Account = _FiAccountService.GetDataByCode(code, startDate, endDate);
            return Ok(Account);
        }
        [HttpGet("get/sub/data/by/Parent/Code/{code}/{codeLength}/{startDate}/{endDate}")]
        public IActionResult GetSubDataByParentCode(string code, int codeLength, DateTime startDate, DateTime endDate, int sectionId)
        {
            var Account = _FiAccountService.GetSubDataByParentCode(code, codeLength, startDate, endDate, sectionId);
            return Ok(Account);
        }
        [HttpGet("get/data/with/parent/by/Code/{code}/{startDate}/{endDate}")]
        public IActionResult GetDataWithParentByCode(string code, DateTime startDate, DateTime endDate)
        {
            var Account = _FiAccountService.GetDataWithParentByCode(code, startDate, endDate);
            return Ok(Account);
        }
        [HttpGet("get/data/by/Hierarchy/{startDate}/{endDate}")]
        public IActionResult GetAllDataByHierarchy(int sectionId, DateTime startDate, DateTime endDate)
        {
            var Account = _FiAccountService.GetAllDataByHierarchy(sectionId, startDate, endDate);
            return Ok(Account);
        }
        //[HttpGet("search")]
        //public IActionResult Search([FromQuery] search searchModel)
        //{
        //    var Add = _FiAccountService.Search(searchModel);
        //    return Ok(Add);
        //}
        [HttpGet("get/Report")]
        public async Task<IActionResult> Get([FromQuery] ReportAccount searchModel, int sectionId, DateTime startDate, DateTime endDate, string code, DateTime PrevstartDate, DateTime PrevendDate, int fiscalYearId)
        {
            byte[] reportFileByString = await _FiAccountService.GenerateReportAsync(searchModel.reportName, searchModel.reportType, sectionId, startDate, endDate, code, PrevstartDate, PrevendDate, fiscalYearId);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

        [HttpGet("Private-Public-Suppliers/Report")]
        public async Task<IActionResult> Test(int fiscalYearId)
        {
            var response = await _FiAccountService.GetPublicPrivateReportData(fiscalYearId);
            return Ok(response);
        }

        [HttpGet("CreditAccounts/Report")]
        public async Task<IActionResult> CreditAccounts(int fiscalYearId)
        {
            var response = await _FiAccountService.GetCreditAccountsReportData(fiscalYearId);
            return Ok(response);
        }

        [HttpGet("ChangeInOwnersEquityReportData/Report")]
        public IActionResult GetChangeInOwnersEquityReportData(int fiscalYearId)
        {
            var response = _FiAccountService.GetChangeInOwnersEquityReportData(fiscalYearId);
            return Ok(response);
        }

        [HttpGet("Test")]
        public async Task<IActionResult> TestAsync(int fiscalYearId)
        {
            return Ok(await _FiAccountService.TestAsync(fiscalYearId));
        }

    }
}
