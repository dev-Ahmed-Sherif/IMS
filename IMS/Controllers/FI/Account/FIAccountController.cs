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
        [HttpGet("getparent/By/code/{code}")]
        public IActionResult Getparent(string code)
        {
            var Account = _FiAccountService.Getparent(code);
            return Ok(Account);
        }

        [HttpGet("get/data/by/Code/{code}/{startDate}/{endDate}")]
        public IActionResult GetAccountMasterReportData(string code,int fiscalYearId)
        {
            var Account = _FiAccountService.GetAccountMasterReportData(code, fiscalYearId);
            return Ok(Account);
        }
        //[HttpGet("get/sub/data/by/Parent/Code/{code}/{codeLength}/{startDate}/{endDate}")]
        //public IActionResult GetAccountMasterDetailsReportData(string code, int codeLength, DateTime startDate, DateTime endDate, int sectionId)
        //{
        //    var Account = _FiAccountService.GetSubDataByParentCode(code, codeLength, startDate, endDate, sectionId);
        //    return Ok(Account);
        //}
        [HttpGet("get/data/with/parent/by/Code/{code}/{startDate}/{endDate}")]
        public IActionResult GetAccountMasterDetailsReportData(string code, int fiscalYearId)
        {
            var Account = _FiAccountService.GetAccountMasterDetailsReportData(code, fiscalYearId);
            return Ok(Account);
        }
        //[HttpGet("get/data/by/Hierarchy/{startDate}/{endDate}")]
        //public IActionResult GetAllDataByHierarchy( int fiscalYearId,string code,int codeLength)
        //{
        //    var Account = _FiAccountService.GetAllDataByHierarchy(fiscalYearId, code,codeLength);
        //    return Ok(Account);
        //}
        //[HttpGet("search")]
        //public IActionResult Search([FromQuery] search searchModel)
        //{
        //    var Add = _FiAccountService.Search(searchModel);
        //    return Ok(Add);
        //}
        [HttpGet("get/Report")]
        public async Task<IActionResult> Get([FromQuery] ReportAccount searchModel, DateTime startDate, DateTime endDate, int sectionId)
        {
            byte[] reportFileByString = await _FiAccountService.GenerateStoreAccountsReport(searchModel.reportName, searchModel.reportType, startDate, endDate, sectionId);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

        [HttpGet("get/FinancialCenter/Report")]
        public async Task<IActionResult> GetFinancialCenterReportData([FromQuery] ReportAccount searchModel, int fiscalYearId, string code)
        {
            byte[] reportFileByString = await _FiAccountService.GenerateFinancialCenterReportAsync(searchModel.reportName, searchModel.reportType, fiscalYearId, code);
            return File(reportFileByString, MediaTypeNames.Application.Pdf, Entities.Helpers.ReportHelper.GetReportDetails(searchModel.reportName, searchModel.reportType));
        }

        //[HttpGet("CreditAccounts/Report")]
        //public async Task<IActionResult> CreditAccounts(int fiscalYearId)
        //{
        //    var response = await _FiAccountService.GetCreditAccountsReportData(fiscalYearId);
        //    return Ok(response);
        //}

        //[HttpGet("ChangeInOwnersEquityReportData/Report")]
        //public IActionResult GetChangeInOwnersEquityReportData(int fiscalYearId)
        //{
        //    var response = _FiAccountService.GetChangeInOwnersEquityReportData(fiscalYearId);
        //    return Ok(response);
        //}

        //[HttpGet("GetFixedAssetsFinancialCenterData/Report")]
        //public async Task<IActionResult> GetFixedAssetsFinancialCenterData(int fiscalYearId)
        //{
        //    return Ok(await _FiAccountService.GetFixedAssetsFinancialCenterData(fiscalYearId));
        //}

    }
}
