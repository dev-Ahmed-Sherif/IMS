using DAL;
using DAL.FI.Account;
using Entities.Constants.FiConstants;
using Entities.Helpers;
using Entities.ReportViewModels;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.NETCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static DAL.FI.Account.FiAccountRepository;

namespace Business.FI.Account
{
    public class FiAccountService
    {
        public FiAccountRepository _FiRepository;

        public FiAccountService(FiAccountRepository FiAccountRepository)
        {
            _FiRepository = FiAccountRepository;

        }
        //---------------------
        // ADD new (FI)_Account
        //---------------------
        public string Add(FiAccountVM ID)
        {
            return _FiRepository.Add(ID);
        }
        //-----------------------------------------------
        // Update (FI)_Account { where id == Account.id }
        //-----------------------------------------------
        public string Update(FiAccountVM ID)
        {
            return _FiRepository.Update(ID);
        }
        //-----------------------------------------------
        // Dellete (FI)_Account { where id == AccountID }
        //-----------------------------------------------
        public string Delete(int ID)
        {
            return _FiRepository.Delete(ID);
        }
        //---------------------
        //Select * (FI)_Account 
        //---------------------
        public List<FiAccountGetVM> GetAll()
        {
            return _FiRepository.GetAll();
        }
        //---------------------------------------------
        // Select * (FI)_Account where {id = AccountID} 
        //---------------------------------------------
        public FiAccountGetVM GetById(int ID)
        {
            return _FiRepository.GetById(ID);
        }
        public PaginatedResult<FiAccountGetVM[]> getAllByPagination(int page, int pageSize)
        {
            return _FiRepository.GetAllByPagination(page, pageSize);
        }
        public List<FiAccountGetVM> GetByName(string accountName)
        {
            return _FiRepository.GetByName(accountName);
        }
        public string Getparent(string code)
        {
            return _FiRepository.Getparent(code);
        }
        public List<AccountItemVM> GetStoreAccountsReportData(DateTime startDate, DateTime endDate, int sectionId)
        {
            return _FiRepository.GetStoreAccountsReportData(startDate,endDate,sectionId);
        }
        public List<AccountItemVM> GetFinancialCenterReportData(int fiscalYearId, string code,int codeLength)
        {
            return _FiRepository.GetFinancialCenterReportData(fiscalYearId, code, codeLength);
        }
        public List<AccountItemByCode> GetAccountMasterReportData(string code, int fiscalYearId)
        {
            return _FiRepository.GetAccountMasterReportData(code,fiscalYearId);
        }
        public List<AccountItemWithParent> GetAccountMasterDetailsReportData(string code,int fiscalYearId)
        {
            return _FiRepository.GetAccountMasterDetailsReportData(code, fiscalYearId);
        }
        public List<withdrawToCostCenter> GetWithdrawToCostCenterReportData(int sectionId, DateTime startDate, DateTime endDate)
        {
            return _FiRepository.GetWithdrawToCostCenterReportData(sectionId, startDate, endDate);
        }
        //public List<AccountItemVM> Search(search searchModel)
        //{
        //    return _FiRepository.Search(searchModel);
        //}

        public async Task<byte[]> GenerateStoreAccountsReport(string reportName, string reportType,DateTime startDate,DateTime endDate,int sectionId)
        {
            // get report file
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            string rdclFilePath = string.Format("{0}ReportsFiles\\FinancialStatment\\{1}.rdlc", fileDirPath, reportName);

            // file encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            // prepare data for report
            LocalReport report = new()
            {
                ReportPath = rdclFilePath
            };

            List<AccountItemVM> FIAccountRE;
            List<AccountItemVM> FIAccountREAdd = new List<AccountItemVM>();

            switch (reportName)
            {
                case "AccountInvestCompReport":
                    {
                        List<string> CommodityStockCodes = new List<string>
                        {
                            "1",
                            "11",
                            "113",
                            "115",
                            "116",
                            "12",
                            "121",
                            "1213",
                            "1215",
                            "1216",
                        };
                        FIAccountRE = GetStoreAccountsReportData(startDate, endDate, sectionId);
                        for (int i = 0; i < FIAccountRE.Count; i++)
                        {
                            if (CommodityStockCodes.Contains(FIAccountRE[i].Code))
                            {
                                if (FIAccountRE[i].AccountNet != 0 || FIAccountRE[i].AccountSubNet != 0)
                                {
                                    FIAccountREAdd.Add(FIAccountRE[i]);
                                }
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountRE", Value = FIAccountREAdd });
                    }
                    break;
                case "AccountCommodityStockReport":
                    {
                        List<string> InvestCompCodes = new List<string>
                        {
                            "31",
                            "311",
                            "312",
                            "313",
                            "34",
                            "16",
                            "1611",
                            "1612",
                            "1613",
                            "164",
                        };
                        FIAccountRE = GetStoreAccountsReportData(startDate, endDate, sectionId);
                        for (int i = 0; i < FIAccountRE.Count; i++)
                        {
                            if (InvestCompCodes.Contains(FIAccountRE[i].Code))
                            {
                                if (FIAccountRE[i].AccountNet != 0 || FIAccountRE[i].AccountSubNet != 0)
                                {
                                    FIAccountREAdd.Add(FIAccountRE[i]);
                                }
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountRE", Value = FIAccountREAdd });
                    }
                    break;
                case "AccountComStockWithdrawTotalReport":
                    {
                        List<string> InvestCompCodes = new List<string>
                        {
                            "311",
                            "312",
                            "313",
                            "34",
                        };
                        FIAccountRE = GetStoreAccountsReportData(startDate, endDate, sectionId);
                        for (int i = 0; i < FIAccountRE.Count; i++)
                        {
                            if (InvestCompCodes.Contains(FIAccountRE[i].Code))
                            {
                                if (FIAccountRE[i].AccountNet != 0 || FIAccountRE[i].AccountSubNet != 0)
                                {
                                    FIAccountREAdd.Add(FIAccountRE[i]);
                                }
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountRE", Value = FIAccountREAdd });
                    }
                    break;
                case "AccountInvestComkWithdrawTotalReport":
                    {
                        List<string> InvestCompCodes = new List<string>
                        {
                            "1213",
                            "1214",
                            "1215",
                            "1216",
                        };
                        FIAccountRE = GetStoreAccountsReportData(startDate, endDate, sectionId);
                        for (int i = 0; i < FIAccountRE.Count; i++)
                        {
                            if (InvestCompCodes.Contains(FIAccountRE[i].Code))
                            {
                                if (FIAccountRE[i].AccountNet != 0 || FIAccountRE[i].AccountSubNet != 0)
                                {
                                    FIAccountREAdd.Add(FIAccountRE[i]);
                                }
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountRE", Value = FIAccountREAdd });
                    }
                    break;
                case "FiWithdrawToCostCenterReport":
                    {
                        List<string> InvestCompCodes = new List<string>
                        {
                            "خامات و مدخلات انتاج",
                            "وقود و زيوت و شحومات",
                            "قطع غيار ومواد و مهمات",
                            "مشتريات بغرض البيع",
                        };
                        List<withdrawToCostCenter> BeforeFilterWithdrawToCostCenterData;
                        List<withdrawToCostCenter> WithdrawToCostCenterData = new List<withdrawToCostCenter>();
                        BeforeFilterWithdrawToCostCenterData = GetWithdrawToCostCenterReportData(sectionId, startDate, endDate);
                        for (int i = 0; i < BeforeFilterWithdrawToCostCenterData.Count; i++)
                        {
                            if (BeforeFilterWithdrawToCostCenterData[i].AccountCode.StartsWith("311"))
                            {
                                BeforeFilterWithdrawToCostCenterData[i].AccountName = InvestCompCodes[0];
                            }
                            else if (BeforeFilterWithdrawToCostCenterData[i].AccountCode.StartsWith("312"))
                            {
                                BeforeFilterWithdrawToCostCenterData[i].AccountName = InvestCompCodes[1];
                            }
                            else if (BeforeFilterWithdrawToCostCenterData[i].AccountCode.StartsWith("313"))
                            {
                                BeforeFilterWithdrawToCostCenterData[i].AccountName = InvestCompCodes[2];
                            }
                            else if (BeforeFilterWithdrawToCostCenterData[i].AccountCode.StartsWith("34"))
                            {
                                BeforeFilterWithdrawToCostCenterData[i].AccountName = InvestCompCodes[3];
                            }
                            WithdrawToCostCenterData.Add(BeforeFilterWithdrawToCostCenterData[i]);
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "FiWithdrawDetailsToCostCenter", Value = WithdrawToCostCenterData });
                    }
                    break;
            }

            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;
        }
        public async Task<byte[]> GenerateFinancialCenterReportAsync(string reportName, string reportType, int fiscalYearId, string code)
        {
            // get report file
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("Business.dll", string.Empty);
            string rdclFilePath = string.Format("{0}ReportsFiles\\FinancialStatment\\{1}.rdlc", fileDirPath, reportName);

            // file encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            // prepare data for report
            LocalReport report = new()
            {
                ReportPath = rdclFilePath
            };

            List<AccountItemVM> AccountActivity = new List<AccountItemVM>();
            List<AccountItemVM> AccountActivityProfit = new List<AccountItemVM>();
            List<AccountItemVM> AccountActivityLose = new List<AccountItemVM>();

            List<AccountItemVM> FIAccountRE;
            List<AccountItemVM> FIAccountREAdd = new List<AccountItemVM>();
            List<AccountItemVM> FIAccountRERemove = new List<AccountItemVM>();

            switch (reportName)
            {
                case "AccountREReport":
                    {
                        FIAccountRE = GetFinancialCenterReportData(fiscalYearId, code, 0);
                        for (int i = 0; i < FIAccountRE.Count; i++)
                        {
                            if (FIAccountRE[i].Code.FirstOrDefault() == '1' || FIAccountRE[i].Code.FirstOrDefault() == '2')
                            {
                                if (FIAccountRE[i].AccountNet != 0 || FIAccountRE[i].AccountSubNet != 0)
                                {
                                    FIAccountREAdd.Add(FIAccountRE[i]);
                                }
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountRE", Value = FIAccountREAdd });
                    }

                    break;
                case "AccountACReport":
                    {
                        FIAccountRE = GetFinancialCenterReportData(fiscalYearId, code, 0);
                        for (int i = 0; i < FIAccountRE.Count; i++)
                        {
                            if (FIAccountRE[i].AccountNet != 0 || FIAccountRE[i].AccountSubNet != 0)
                            {
                                if (FIAccountRE[i].Code.FirstOrDefault() == '1')
                                {
                                    FIAccountREAdd.Add(FIAccountRE[i]);
                                }
                                else if (FIAccountRE[i].Code.FirstOrDefault() == '2')
                                {
                                    FIAccountRERemove.Add(FIAccountRE[i]);
                                }
                            }

                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountRE", Value = FIAccountREAdd });
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountREv2", Value = FIAccountRERemove });
                    }
                    break;
                case "AccountProfitLoseActivityReport":
                    {
                        List<string> codes = new List<string>
                        {
                            "43",
                            "44",
                            "35",
                            "38",
                        };
                        foreach (string itemCode in codes)
                        {
                            AccountActivity = GetFinancialCenterReportData(fiscalYearId, itemCode, 4);
                            for (int i = 0; i < AccountActivity.Count; i++)
                            {
                                if (AccountActivity[i].AccountNet != 0 || AccountActivity[i].AccountSubNet != 0)
                                {
                                    if (AccountActivity[i].Code.StartsWith("43") || AccountActivity[i].Code.StartsWith("44"))
                                    {
                                        AccountActivityProfit.Add(AccountActivity[i]);
                                    }
                                    else if (AccountActivity[i].Code.StartsWith("35") || AccountActivity[i].Code.StartsWith("38"))
                                    {
                                        AccountActivityLose.Add(AccountActivity[i]);
                                    }
                                }
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfit", Value = AccountActivityProfit });
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountLose", Value = AccountActivityLose });
                    }
                    break;
                case "AccountTradingActivityReport":
                    {
                        List<string> codes = new List<string>
                        {
                            "41",
                            "42",
                            "37",
                        };
                        foreach (string itemCode in codes)
                        {
                            AccountActivity = GetFinancialCenterReportData(fiscalYearId, itemCode, 5);
                            for (int i = 0; i < AccountActivity.Count; i++)
                            {
                                if (AccountActivity[i].AccountNet != 0 || AccountActivity[i].AccountSubNet != 0)
                                {
                                    if (AccountActivity[i].Code.ToString().StartsWith("41")
                                        || AccountActivity[i].Code.ToString().StartsWith("42"))
                                    {
                                        AccountActivityProfit.Add(AccountActivity[i]);
                                    }
                                    else if (AccountActivity[i].Code.ToString().StartsWith("37"))
                                    {
                                        AccountActivityLose.Add(AccountActivity[i]);
                                    }
                                }
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfit", Value = AccountActivityProfit });
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountLose", Value = AccountActivityLose });
                        //ReportParameter startDateParam = new() { Name = "StartDate" };
                        //startDateParam.Values.Add(startDate.ToShortDateString());
                        //ReportParameter endDateParam = new() { Name = "EndDate" };
                        //endDateParam.Values.Add(endDate.ToShortDateString());
                        //report.SetParameters([startDateParam, endDateParam]);
                    }
                    break;
                case "AccountGoodsActivityReport":
                    {
                        List<string> codes = new List<string>
                        {
                            "164",
                            "36",
                            "34",
                        };
                        foreach (string itemCode in codes)
                        {
                            AccountActivity = GetFinancialCenterReportData(fiscalYearId, itemCode, 5);
                            for (int i = 0; i < AccountActivity.Count; i++)
                            {
                                if (AccountActivity[i].AccountNet != 0 || AccountActivity[i].AccountSubNet != 0)
                                {
                                    if (AccountActivity[i].Code.ToString().StartsWith("1"))
                                    {
                                        AccountActivityProfit.Add(AccountActivity[i]);
                                    }
                                    else if (AccountActivity[i].Code.ToString().StartsWith("3"))
                                    {
                                        AccountActivityLose.Add(AccountActivity[i]);
                                    }
                                }
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfit", Value = AccountActivityProfit });
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountLose", Value = AccountActivityLose });
                    }
                    break;
                case "AccountMasterReport":
                    {
                        List<AccountItemByCode> AccountMaster = GetAccountMasterReportData(code, fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountMaster", Value = AccountMaster });
                    }
                    break;
                case "AccountMasterDetailsReport":
                    {
                        List<AccountItemWithParent> AccountMasterDetails = GetAccountMasterDetailsReportData(code, fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountMasterDetails", Value = AccountMasterDetails });
                    }
                    break;
                case "AccountWaterAndWasteWaterIncomeStatementReport":
                    {
                        List<AccountItemVM> FIAccountREAddOne = new List<AccountItemVM>();
                        List<AccountItemVM> FIAccountREAddTwo = new List<AccountItemVM>();
                        List<AccountItemVM> FIAccountREAddThree = new List<AccountItemVM>();

                        List<string> Revenues = new List<string>
                        {
                            "41",
                            "411",
                            "412",
                            "413",
                            "414",
                            "415",
                            "416",
                            "417",
                            "42",
                        };
                        AccountActivity = GetFinancialCenterReportData(fiscalYearId, null, 0);
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (Revenues.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAdd.Add(AccountActivity[i]);
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfit", Value = FIAccountREAdd });

                        List<string> Invest = new List<string>
                        {

                            "433",
                            "434",
                            "435",

                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (Invest.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddOne.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitOne", Value = FIAccountREAddOne });

                        List<string> codes = new List<string>
                        {
                            "352",
                            "353",
                            "354",
                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (codes.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddTwo.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitTwo", Value = FIAccountREAddTwo });

                        List<string> Revenues2 = new List<string>
                        {
                            "442",
                            "443",
                            "444",
                            "445",
                            "446",
                            "447",
                            "448",
                            "353",
                            "441",
                            "357",
                            "355",
                            "356",
                            "358",
                            "333",
                            "431",
                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (codes.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddThree.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitThree", Value = FIAccountREAddThree });
                        //report.DataSources.Add(new ReportDataSource() { Name = "AccountLose", Value = AccountActivityLose });
                    }
                    break;
                case "AccountIncomeStatementReport":
                    {
                        List<AccountItemVM> FIAccountREAddOne = new List<AccountItemVM>();
                        List<AccountItemVM> FIAccountREAddTwo = new List<AccountItemVM>();
                        List<AccountItemVM> FIAccountREAddThree = new List<AccountItemVM>();

                        List<string> Revenues = new List<string>
                        {
                            "41",
                            "411",
                            "412",
                            "413",
                            "414",
                            "415",
                            "416",
                            "417",
                            "42",
                        };
                        AccountActivity = GetFinancialCenterReportData(fiscalYearId, null, 0);
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (Revenues.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAdd.Add(AccountActivity[i]);
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfit", Value = FIAccountREAdd });

                        List<string> Invest = new List<string>
                        {

                            "433",
                            "434",
                            "435",

                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (Invest.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddOne.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitOne", Value = FIAccountREAddOne });

                        List<string> codes = new List<string>
                        {
                            "352",
                            "353",
                            "354",
                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (codes.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddTwo.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitTwo", Value = FIAccountREAddTwo });

                        List<string> Revenues2 = new List<string>
                        {
                            "442",
                            "443",
                            "444",
                            "445",
                            "446",
                            "447",
                            "448",

                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (Revenues2.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddThree.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitThree", Value = FIAccountREAddThree });
                        //report.DataSources.Add(new ReportDataSource() { Name = "AccountLose", Value = AccountActivityLose });
                    }
                    break;
                case "AccountProductionAndAddedValueReport":
                    {
                        List<AccountItemVM> FIAccountREAddOne = new List<AccountItemVM>();
                        List<AccountItemVM> FIAccountREAddTwo = new List<AccountItemVM>();
                        List<AccountItemVM> FIAccountREAddThree = new List<AccountItemVM>();
                        List<AccountItemVM> FIAccountREAddfour = new List<AccountItemVM>();

                        List<string> Revenues = new List<string>
                        {
                           
                            "411",
                            "412",
                            "414",
                            "415",
                             "417",
                            
                        };
                        AccountActivity = GetFinancialCenterReportData(fiscalYearId, null, 0);
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (Revenues.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAdd.Add(AccountActivity[i]);
                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfit", Value = FIAccountREAdd });

                       
                       

                        List<string> codes = new List<string>
                        {
                            
                            "34",
                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (codes.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddTwo.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitTwo", Value = FIAccountREAddTwo });

                        List<string> Revenues2 = new List<string>
                        {
                            "332",
                           
                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (Revenues2.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddThree.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitThree", Value = FIAccountREAddThree });
                        //report.DataSources.Add(new ReportDataSource() { Name = "AccountLose", Value = AccountActivityLose });


                        List<string> Invest = new List<string>
                        {

                            "3635",
                            "3636",


                        };
                        for (int i = 0; i < AccountActivity.Count; i++)
                        {
                            if (Invest.Contains(AccountActivity[i].Code))
                            {
                                FIAccountREAddfour.Add(AccountActivity[i]);

                            }
                        }
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountProfitfour", Value = FIAccountREAddfour });

                    }
                    break;



                case "AccountCreditAccountsReport":
                    {
                        List<FiAccountItemBalancesViewModel> CreditAccounts;
                        CreditAccounts = await GetCreditAccountsReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountItemReport", Value = CreditAccounts });

                    }
                    break;
                case "AccountSuppliersReport":
                    {
                        List<FiAccountItemBalancesViewModel> AccountSuppliers;
                        AccountSuppliers = await GetPublicPrivateReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountItemReport", Value = AccountSuppliers });
                    }
                    break;
                case "AccountTrailBalanceReport":
                    {
                        List<FiAccountItemBalancesViewModel> TrailBalance;
                        TrailBalance = await GetTriaBalanceReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountItemReport", Value = TrailBalance });
                    }
                    break;
                case "AccountChangeOwnerShipRightsReport":
                    {
                        List<FiChangeInOwnersEquityViewModel> AccountSuppliers;
                        AccountSuppliers =  GetChangeInOwnersEquityReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountItem", Value = AccountSuppliers });
                    }
                    break;
                case "AccountCashFlowsReport":
                    {
                        List<FiAccountItemBalancesViewModel> AccountSuppliers;
                        AccountSuppliers = await GetPublicPrivateReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountRE", Value = AccountSuppliers });
                    }
                    break;
                case "AccountDebitAccountsReport":
                    {
                        List<FiAccountItemBalancesViewModel> DebitAccounts = new List<FiAccountItemBalancesViewModel>();
                        //AccountSuppliers = await GetPublicPrivateReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "DebitBalances", Value = DebitAccounts });
                    }
                    break;
                case "AccountIncomeByMonthReport":
                    {
                        List<FiAccountItemBalancesViewModel> Revenues = new List<FiAccountItemBalancesViewModel>();
                        //AccountSuppliers = await GetPublicPrivateReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "Revenues", Value = Revenues });
                    }
                    break;
                case "AccountPermanentAdvancesReport":
                    {
                        List<FiAccountItemBalancesViewModel> PermanentAdvances = new List<FiAccountItemBalancesViewModel>();
                        //AccountSuppliers = await GetPublicPrivateReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "PermanentAdvances", Value = PermanentAdvances });
                    }
                    break;
                case "AccountTemporaryAdvancesReport":
                    {
                        List<FiAccountItemBalancesViewModel> TemporaryAdvances = new List<FiAccountItemBalancesViewModel>();
                        //AccountSuppliers = await GetPublicPrivateReportData(fiscalYearId);
                        report.DataSources.Add(new ReportDataSource() { Name = "TemporaryAdvances", Value = TemporaryAdvances });
                    }
                    break;
                case "QualitativeAnalysisListReport":
                    {
                        List<AccountItemVM> QualitativeAnalysis = new List<AccountItemVM>();
                        QualitativeAnalysis = GetFinancialCenterReportData(fiscalYearId, null, 0);
                        report.DataSources.Add(new ReportDataSource() { Name = "TemporaryAdvances", Value = QualitativeAnalysis });
                    }
                    break;
            }

            byte[] renderedBytes = report.Render(reportType);
            return renderedBytes;
        }
        public async Task<List<FiAccountItemBalancesViewModel>> GetPublicPrivateReportData(int fiscalYearId)
        {
            var publicSuppliers =
                await
                _FiRepository
                .GetAccountItemsByAccountCodeReportData
                (AccountsCodes.موردين_قطاع_عام, fiscalYearId);

            var privateSuppliers =
                await
                _FiRepository
                .GetAccountItemsByAccountCodeReportData
                (AccountsCodes.موردين_قطاع_خاص, fiscalYearId);

            return publicSuppliers.Union(privateSuppliers).ToList();
        }

        public async Task<List<FiAccountItemBalancesViewModel>> GetCreditAccountsReportData(int fiscalYearId)
        {
            var creditAccounts =
                await
                _FiRepository
                .GetAccountItemsByAccountCodeReportData
                (AccountsCodes.حسابات_دائنة_أخرى, fiscalYearId);

            return creditAccounts;
        }

        public List<FiChangeInOwnersEquityViewModel> GetChangeInOwnersEquityReportData(int fiscalYearId)
        {
            return _FiRepository.GetChangeInOwnersEquityReportData(fiscalYearId);
        }

        public async Task<List<FixedAssetsFinancialCenterViewModel>> GetFixedAssetsFinancialCenterData(int fiscalYearId)
        {
            return await _FiRepository.GetFixedAssetsFinancialCenterData(fiscalYearId);
        }

        public async Task<List<FiAccountItemBalancesViewModel>> GetTriaBalanceReportData(int fiscalYearId)
        {
            return await _FiRepository.GetTriaBalanceReportData(fiscalYearId);
        }
    }
}
