using DAL;
using DAL.FI.Account;
using Entities.Constants.FiConstants;
using Entities.Helpers;
using Entities.Models.FI.Entry;
using Entities.ReportViewModels;
using Entities.ViewModels.FI.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.Map.WebForms.BingMaps;
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
        public FiAccountGetParentVM Getparent(string code)
        {
            return _FiRepository.GetParent(code);
        }
        public List<AccountItemVM> GetStoreAccountsReportData(DateTime startDate, DateTime endDate, int sectionId)
        {
            return _FiRepository.GetStoreAccountsReportData(startDate, endDate, sectionId);
        }
        public async Task<List<AccountItemVM>> GetFinancialCenterReportData(int fiscalYearId, string code, int codeLength)
        {
            return await _FiRepository.GetFinancialCenterReportData(fiscalYearId, code, codeLength);
        }
        public List<AccountItemByCode> GetAccountMasterReportData(string code, int fiscalYearId)
        {
            return _FiRepository.GetAccountMasterReportData(code, fiscalYearId);
        }
        public List<AccountItemWithParent> GetAccountMasterDetailsReportData(string code, int fiscalYearId)
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

        public async Task<byte[]> GenerateStoreAccountsReport(string reportName, string reportType, DateTime startDate, DateTime endDate, int sectionId)
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
                        List<FixedAssetsFinancialCenterViewModel> fixedAssetsArray;
                        FIAccountRE = await GetFinancialCenterReportData(fiscalYearId, code, 0);
                        fixedAssetsArray = await GetFixedAssetsFinancialCenterData(fiscalYearId);
                        List<string> SumofAssets = new List<string> { "1" };
                        List<string> SumofPropertyRightsAndObligations = new List<string> { "2" };
                        // Non - Current Fixed Assets Filter
                        List<string> NonCurrentAssetsFirst = new List<string>
                        {
                            "121",
                            "122",
                        };
                        List<string> SumNonCurrentAssetsFirst = new List<string>
                        {
                            "12"
                        };
                        List<string> NonCurrentAssetsSecond = new List<string>
                        {
                            "131"
                        };
                        List<string> NonCurrentAssetsThird = new List<string>
                        {
                            "1511",
                            "1512",
                            "1513",
                        };
                        List<string> NonCurrentAssetsFourth = new List<string>
                        {
                            "151",
                            "152",
                            "153",
                        };
                        List<string> NonCurrentAssetsFifth = new List<string>
                        {
                            "132",
                            "133",
                            "134",
                        };
                        List<string> NonCurrentAssetsSixth = new List<string>
                        {
                            "135",
                            "136",
                        };
                        List<string> NonCurrentAssetsSeventh = new List<string>
                        {
                            "13",
                        };
                        List<string> NonCurrentAssetsEighth = new List<string>
                        {
                            "14",
                        };
                        List<string> NonCurrentAssetsNinth = new List<string>
                        {
                            "15",
                        };

                        // Current Fixed Assets Filter
                        List<string> CurrentAssetsFirst = new List<string>
                        {
                            "161",
                            "162",
                            "163",
                            "164",
                            "165",
                            "166",
                        };
                        List<string> SumCurrentAssetsFirst = new List<string> { "16" };
                        List<string> CurrentAssetsSecond = new List<string>
                        {
                            "171",
                        };
                        List<string> CurrentAssetsThird = new List<string>
                        {
                            "266",
                        };
                        List<string> CurrentAssetsFourth = new List<string>
                        {
                            "1716",
                        };
                        List<string> CurrentAssetsFivth = new List<string>
                        {
                            "14"
                        };
                        List<string> CurrentAssetsSixth = new List<string>
                        {
                            "174",
                            "175",
                            "176",
                            "177",
                        };
                        List<string> CurrentAssetsSeventh = new List<string>
                        {
                            "173",
                            "1731",
                            "1732",
                        };
                        List<string> CurrentAssetsEighth = new List<string>
                        {
                            "18",
                        };
                        List<string> CurrentAssetsNinth = new List<string>
                        {
                            "191",
                            "192",
                            "193",
                            "194",
                        };
                        List<string> CurrentAssetsTenth = new List<string>
                        {
                            "19",
                        };
                        List<string> CurrentAssetsEleventh = new List<string>
                        {
                            "17",
                        };

                        List<string> PropertyRightsFirst = new List<string>
                        {
                            "211",
                            "212",
                            "213",
                        };
                        List<string> PropertyRightsSecond = new List<string>
                        {
                            "221",
                            "222",
                            "223",
                            "224"
                        };
                        List<string> PropertyRightsThird = new List<string>
                        {
                            "23",
                            "24"
                        };
                        List<string> NonCurrentObligations = new List<string>
                        {
                            "251",
                            "252",
                            "253",
                            "254",
                            "255"
                        };
                        List<string> CurrentObligationsFirst = new List<string>
                        {
                            "267",
                            "268",
                            "269",
                        };
                        List<string> CurrentObligationsSecond = new List<string>
                        {
                            "271",
                        };
                        List<string> CurrentObligationsThird = new List<string>
                        {
                            "281",
                            "282",
                            "283",
                            "2831",
                            "28311",
                            "2832",
                            "284",
                            "285",
                            "286",
                            "287",
                            "288"
                        };
                        List<string> CurrentObligationsFourth = new List<string>
                        {
                            "273",
                            "2899"
                        };
                        List<string> Payment = new List<string>
                        {
                            "3"
                        };
                        List<string> Income = new List<string>
                        {
                            "4"
                        };
                        for (int i = 0; i < FIAccountRE.Count; i++)
                        {
                            FIAccountREAdd.Add(FIAccountRE[i]);
                            if (FIAccountRE[i].Code.FirstOrDefault() == '1' || FIAccountRE[i].Code.FirstOrDefault() == '2')
                            {
                                //if (FIAccountRE[i].AccountNet != 0 || FIAccountRE[i].AccountSubNet != 0)
                                //{

                                //}
                            }
                        }

                        // Non - Current Fixed Assets
                        List<AccountItemVM> SumofAssetsArray = new List<AccountItemVM>();
                        List<AccountItemVM> SumofPropertyRightsAndObligationsArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsFirstArray = new List<AccountItemVM>();
                        List<AccountItemVM> SumNonCurrentAssetsFirstArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsSecondArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsThirdArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsFourthArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsFifthArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsSixthArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsSeventhArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsEighthArray = new List<AccountItemVM>();
                        List<AccountItemVM> NonCurrentAssetsNinthArray = new List<AccountItemVM>();

                        // Current Fixed Assets Report Data
                        List<AccountItemVM> CurrentAssetsFirstArray = new List<AccountItemVM>();
                        List<AccountItemVM> SumCurrentAssetsFirstArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsSecondArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsThirdArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsFourthArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsFivthArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsSixthArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsSeventhArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsEighthArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsNinthArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsTenthArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentAssetsEleventhArray = new List<AccountItemVM>();

                        List<AccountItemVM> PropertyRightsFirstArray = new List<AccountItemVM>();
                        List<AccountItemVM> PropertyRightsSecondArray = new List<AccountItemVM>();
                        List<AccountItemVM> PropertyRightsThirdArray = new List<AccountItemVM>();

                        List<AccountItemVM> NonCurrentObligationsArray = new List<AccountItemVM>();

                        List<AccountItemVM> CurrentObligationsFirstArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentObligationsSecondArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentObligationsThirdArray = new List<AccountItemVM>();
                        List<AccountItemVM> CurrentObligationsFourthArray = new List<AccountItemVM>();

                        List<AccountItemVM> PaymentArray = new List<AccountItemVM>();
                        List<AccountItemVM> IncomeArray = new List<AccountItemVM>();

                        for (int i = 0; i < FIAccountREAdd.Count; i++)
                        {
                            for (int j = 0; j < SumofAssets.Count; j++)
                            {
                                if (SumofAssets[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    SumofAssetsArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < SumofPropertyRightsAndObligations.Count; j++)
                            {
                                if (SumofPropertyRightsAndObligations[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    SumofPropertyRightsAndObligationsArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsFirst.Count; j++)
                            {
                                if (NonCurrentAssetsFirst[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsFirstArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < SumNonCurrentAssetsFirst.Count; j++)
                            {
                                if (SumNonCurrentAssetsFirst[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    SumNonCurrentAssetsFirstArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsSecond.Count; j++)
                            {
                                if (NonCurrentAssetsSecond[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsSecondArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsThird.Count; j++)
                            {
                                if (NonCurrentAssetsThird[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsThirdArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsFourth.Count; j++)
                            {
                                if (NonCurrentAssetsFourth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsFourthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsFifth.Count; j++)
                            {
                                if (NonCurrentAssetsFifth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsFifthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsSixth.Count; j++)
                            {
                                if (NonCurrentAssetsSixth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsSixthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsSeventh.Count; j++)
                            {
                                if (NonCurrentAssetsSeventh[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsSeventhArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsEighth.Count; j++)
                            {
                                if (NonCurrentAssetsEighth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsEighthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentAssetsNinth.Count; j++)
                            {
                                if (NonCurrentAssetsNinth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentAssetsNinthArray.Add(FIAccountREAdd[i]);
                                }
                            }

                            for (int j = 0; j < CurrentAssetsFirst.Count; j++)
                            {
                                if (CurrentAssetsFirst[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsFirstArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < SumCurrentAssetsFirst.Count; j++)
                            {
                                if (SumCurrentAssetsFirst[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    SumCurrentAssetsFirstArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsSecond.Count; j++)
                            {
                                if (CurrentAssetsSecond[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsSecondArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsThird.Count; j++)
                            {
                                if (CurrentAssetsThird[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsThirdArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsFourth.Count; j++)
                            {
                                if (CurrentAssetsFourth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsFourthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsFivth.Count; j++)
                            {
                                if (CurrentAssetsFivth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsFivthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsSixth.Count; j++)
                            {
                                if (CurrentAssetsSixth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsSixthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsSeventh.Count; j++)
                            {
                                if (CurrentAssetsSeventh[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsSeventhArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsEighth.Count; j++)
                            {
                                if (CurrentAssetsEighth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsEighthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsNinth.Count; j++)
                            {
                                if (CurrentAssetsNinth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsNinthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsTenth.Count; j++)
                            {
                                if (CurrentAssetsTenth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsTenthArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentAssetsEleventh.Count; j++)
                            {
                                if (CurrentAssetsEleventh[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentAssetsEleventhArray.Add(FIAccountREAdd[i]);
                                }
                            }

                            for (int j = 0; j < PropertyRightsFirst.Count; j++)
                            {
                                if (PropertyRightsFirst[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    PropertyRightsFirstArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < PropertyRightsSecond.Count; j++)
                            {
                                if (PropertyRightsSecond[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    PropertyRightsSecondArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < PropertyRightsThird.Count; j++)
                            {
                                if (PropertyRightsThird[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    PropertyRightsThirdArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < NonCurrentObligations.Count; j++)
                            {
                                if (NonCurrentObligations[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    NonCurrentObligationsArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentObligationsFirst.Count; j++)
                            {
                                if (CurrentObligationsFirst[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentObligationsFirstArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentObligationsSecond.Count; j++)
                            {
                                if (CurrentObligationsSecond[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentObligationsSecondArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentObligationsThird.Count; j++)
                            {
                                if (CurrentObligationsThird[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentObligationsThirdArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < CurrentObligationsFourth.Count; j++)
                            {
                                if (CurrentObligationsFourth[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    CurrentObligationsFourthArray.Add(FIAccountREAdd[i]);
                                }
                            }

                            for (int j = 0; j < Payment.Count; j++)
                            {
                                if (Payment[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    PaymentArray.Add(FIAccountREAdd[i]);
                                }
                            }
                            for (int j = 0; j < Income.Count; j++)
                            {
                                if (Income[j].Equals(FIAccountREAdd[i].Code))
                                {
                                    IncomeArray.Add(FIAccountREAdd[i]);
                                }
                            }
                        }


                        report.DataSources.Add(new ReportDataSource() { Name = "FixedAssets", Value = fixedAssetsArray });

                        // Non - Current Fixed Assets Data Sets
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsFirst", Value = NonCurrentAssetsFirstArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "SumNonCurrentAssetsFirst", Value = SumNonCurrentAssetsFirstArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsSecond", Value = NonCurrentAssetsSecondArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsThird", Value = NonCurrentAssetsThirdArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsFourth", Value = NonCurrentAssetsFourthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsFifth", Value = NonCurrentAssetsFifthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsSixth", Value = NonCurrentAssetsSixthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsSeventh", Value = NonCurrentAssetsSeventhArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsEighth", Value = NonCurrentAssetsEighthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentAssetsNinth", Value = NonCurrentAssetsNinthArray });

                        // Current Fixed Assets Data Sets
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsFirst", Value = CurrentAssetsFirstArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "SumCurrentAssetsFirst", Value = SumCurrentAssetsFirstArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsSecond", Value = CurrentAssetsSecondArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsThird", Value = CurrentAssetsThirdArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsFourth", Value = CurrentAssetsFourthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsFivth", Value = CurrentAssetsFivthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsSixth", Value = CurrentAssetsSixthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsSeventh", Value = CurrentAssetsSeventhArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsEighth", Value = CurrentAssetsEighthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsNinth", Value = CurrentAssetsNinthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsTenth", Value = CurrentAssetsTenthArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentAssetsEleventh", Value = CurrentAssetsEleventhArray });

                        report.DataSources.Add(new ReportDataSource() { Name = "PropertyRightsFirst", Value = PropertyRightsFirstArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "PropertyRightsSecond", Value = PropertyRightsSecondArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "PropertyRightsThird", Value = PropertyRightsThirdArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "NonCurrentObligations", Value = NonCurrentObligationsArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentObligationsFirst", Value = CurrentObligationsFirstArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentObligationsSecond", Value = CurrentObligationsSecondArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentObligationsThird", Value = CurrentObligationsThirdArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "CurrentObligationsFourth", Value = CurrentObligationsFourthArray });

                        report.DataSources.Add(new ReportDataSource() { Name = "Payment", Value = PaymentArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "Income", Value = IncomeArray });

                        report.DataSources.Add(new ReportDataSource() { Name = "SumofAssets", Value = SumofAssetsArray });
                        report.DataSources.Add(new ReportDataSource() { Name = "SumofPropertyRightsAndObligations", Value = SumofPropertyRightsAndObligationsArray });
                    }

                    break;
                case "AccountACReport":
                    {
                        FIAccountRE = await GetFinancialCenterReportData(fiscalYearId, code, 0);
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
                            AccountActivity = await GetFinancialCenterReportData(fiscalYearId, itemCode, 4);
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
                            AccountActivity = await GetFinancialCenterReportData(fiscalYearId, itemCode, 5);
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
                            AccountActivity = await GetFinancialCenterReportData(fiscalYearId, itemCode, 5);
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
                        AccountActivity = await GetFinancialCenterReportData(fiscalYearId, null, 0);
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
                        AccountActivity = await GetFinancialCenterReportData(fiscalYearId, null, 0);
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
                        AccountActivity = await GetFinancialCenterReportData(fiscalYearId, null, 0);
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
                        List<FiChangeInOwnersEquityViewModel> AccountSuppliers,
                                                              equityCapital = new List<FiChangeInOwnersEquityViewModel>(),
                                                              stageProfitsAndLosses = new List<FiChangeInOwnersEquityViewModel>(),
                                                              treasuryShares = new List<FiChangeInOwnersEquityViewModel>(),
                                                              precautions = new List<FiChangeInOwnersEquityViewModel>();

                        AccountSuppliers = GetChangeInOwnersEquityReportData(fiscalYearId);

                        for (int i = 0; i < AccountSuppliers.Count; i++)
                        {
                            if (AccountSuppliers[i].AccountCode == "2113")
                            {
                                equityCapital.Add(AccountSuppliers[i]);
                            }
                            if (AccountSuppliers[i].AccountCode == "23")
                            {
                                stageProfitsAndLosses.Add(AccountSuppliers[i]);
                            }
                            if (AccountSuppliers[i].AccountCode == "24")
                            {
                                treasuryShares.Add(AccountSuppliers[i]);
                            }
                            if (AccountSuppliers[i].AccountCode == "22")
                            {
                                precautions.Add(AccountSuppliers[i]);
                            }
                        }

                        report.DataSources.Add(new ReportDataSource() { Name = "EquityCapital", Value = equityCapital });
                        report.DataSources.Add(new ReportDataSource() { Name = "StageProfitsAndLosses", Value = stageProfitsAndLosses });
                        report.DataSources.Add(new ReportDataSource() { Name = "TreasuryShares", Value = treasuryShares });
                        report.DataSources.Add(new ReportDataSource() { Name = "AccountItem", Value = precautions });
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
                        List<AccountItemVM> QualitativeAnalysis,
                                            materialsData = new List<AccountItemVM>(),
                                            wagesData = new List<AccountItemVM>(),
                                            purchasedServicesData = new List<AccountItemVM>(),
                                            destructionData = new List<AccountItemVM>(),
                                            restExpensesData = new List<AccountItemVM>(),
                                            purchasesForSalesData = new List<AccountItemVM>(),
                                            burdensAndLossesData = new List<AccountItemVM>(),
                                            variousBurdensAndLossesData = new List<AccountItemVM>(),
                                            restBurdensAndLossesData = new List<AccountItemVM>();

                        QualitativeAnalysis = await GetFinancialCenterReportData(fiscalYearId, "3", 7);
                        List<string> materials = new List<string> { "31", "311", "312", "313", "314", "315", "316" };
                        decimal sumMaterials = 0;

                        List<string> wages = new List<string> { "32", "321", "322", "323" };
                        decimal sumWages = 0;

                        List<string> purchasedServices = new List<string> { "33", "331", "3311", "3312", "3314", "3315", "3316", "3317", "3318" };
                        decimal sumPurchasedServices = 0;

                        List<string> destruction = new List<string> { "332", "3321", "3322" };
                        decimal sumDestruction = 0;

                        List<string> restExpenses = new List<string> { "333", "334", "335", "336" };
                        decimal sumRestExpenses = 0;

                        decimal sumExpenses = sumPurchasedServices + sumDestruction + sumRestExpenses;

                        List<string> purchasesForSale = new List<string> { "34" };
                        decimal sumPurchasesForSale = 0;

                        List<string> burdensAndLosses = new List<string> { "35", "351", "352", "353" };

                        List<string> variousBurdensAndLosses = new List<string> { "354", "3541", "3542", "3543", "3544", "3545" };

                        decimal sumVariousBurdensAndLosses = 0;
                        List<string> restBurdensAndLosses = new List<string> { "355", "356", "357", "358", "359" };

                        for (int i = 0; i < QualitativeAnalysis.Count; i++)
                        {
                            for (int j = 0; j < materials.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(materials[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < wages.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(wages[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < purchasedServices.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(purchasedServices[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < destruction.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(destruction[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < restExpenses.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(restExpenses[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < purchasesForSale.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(purchasesForSale[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < burdensAndLosses.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(burdensAndLosses[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < variousBurdensAndLosses.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(variousBurdensAndLosses[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < restBurdensAndLosses.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(restBurdensAndLosses[j]))
                                {
                                    materialsData.Add(QualitativeAnalysis[i]);
                                }
                            }

                        }

                        //materialsData = materialsData.OrderBy(e => e.Code).ToList();

                        report.DataSources.Add(new ReportDataSource() { Name = "MaterialsData", Value = materialsData });
                        report.DataSources.Add(new ReportDataSource() { Name = "WagesData", Value = wagesData });
                        report.DataSources.Add(new ReportDataSource() { Name = "PurchasedServicesData", Value = purchasedServicesData });
                        report.DataSources.Add(new ReportDataSource() { Name = "DestructionData", Value = destructionData });
                        report.DataSources.Add(new ReportDataSource() { Name = "RestExpensesData", Value = restExpensesData });
                        report.DataSources.Add(new ReportDataSource() { Name = "PurchasesForSalesData", Value = purchasesForSalesData });
                        report.DataSources.Add(new ReportDataSource() { Name = "BurdensAndLossesData", Value = burdensAndLossesData });
                        report.DataSources.Add(new ReportDataSource() { Name = "VariousBurdensAndLossesData", Value = variousBurdensAndLossesData });
                        report.DataSources.Add(new ReportDataSource() { Name = "RestBurdensAndLossesData", Value = restBurdensAndLossesData });

                        decimal sumFirstBranch = sumMaterials + sumWages + sumExpenses + sumPurchasesForSale + sumVariousBurdensAndLosses;

                        List<string> productionCosts1 = new List<string> { "361", "3611", "3612", "3613", "3614", "3615", "3616" };
                        decimal sumProductionCosts1 = 0;
                        List<string> productionCosts2 = new List<string> { "362", "3621", "3622", "3623" };
                        decimal sumProductionCosts2 = 0;
                        List<string> productionCosts3 = new List<string> { "363", "3631", "36311", "36312", "36314", "36315", "36316", "36317", "36318" };
                        decimal sumProductionCosts3 = 0;
                        List<string> productionCosts4 = new List<string> { "3632", "36321", "36322" };
                        decimal sumProductionCosts4 = 0;
                        List<string> productionCosts5 = new List<string> { "3633", "3634", "3635", "3635", "3636" };
                        decimal sumProductionCosts5 = 0;

                        List<AccountItemVM> productionCosts1Data = new List<AccountItemVM>(),
                                            productionCosts2Data = new List<AccountItemVM>(),
                                            productionCosts3Data = new List<AccountItemVM>(),
                                            productionCosts4Data = new List<AccountItemVM>(),
                                            productionCosts5Data = new List<AccountItemVM>();


                        for (int i = 0; i < QualitativeAnalysis.Count; i++)
                        {
                            for (int j = 0; j < productionCosts1.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(productionCosts1[j]))
                                {
                                    productionCosts1Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < productionCosts2.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(productionCosts2[j]))
                                {
                                    productionCosts2Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < productionCosts3.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(productionCosts3[j]))
                                {
                                    productionCosts3Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < productionCosts4.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(productionCosts4[j]))
                                {
                                    productionCosts4Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < productionCosts5.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(productionCosts5[j]))
                                {
                                    productionCosts5Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                        }

                        report.DataSources.Add(new ReportDataSource() { Name = "ProductionCosts1Data", Value = productionCosts1Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "ProductionCosts2Data", Value = productionCosts2Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "ProductionCosts3Data", Value = productionCosts3Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "ProductionCosts4Data", Value = productionCosts4Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "ProductionCosts5Data", Value = productionCosts5Data });

                        decimal sumProductionCosts = sumProductionCosts1 + sumProductionCosts2 + sumProductionCosts3 + sumProductionCosts4
                                                    + sumProductionCosts5;

                        List<string> marketingCosts1 = new List<string> { "371", "3711", "3712", "3713", "3714", "3715", "3716" };
                        decimal sumMarketingCosts1 = 0;
                        List<string> marketingCosts2 = new List<string> { "372", "3721", "3722", "3723" };
                        decimal sumMarketingCosts2 = 0;
                        List<string> marketingCosts3 = new List<string> { "373", "3731", "37311", "37312", "37314", "37315", "37316", "37317", "37318" };
                        decimal sumMarketingCosts3 = 0;
                        List<string> marketingCosts4 = new List<string> { "3732", "37321", "37322" };
                        decimal sumMarketingCosts4 = 0;
                        List<string> marketingCosts5 = new List<string> { "3733", "3734", "3735", "3735", "3736" };
                        decimal sumMarketingCosts5 = 0;

                        List<AccountItemVM> marketingCosts1Data = new List<AccountItemVM>(),
                                            marketingCosts2Data = new List<AccountItemVM>(),
                                            marketingCosts3Data = new List<AccountItemVM>(),
                                            marketingCosts4Data = new List<AccountItemVM>(),
                                            marketingCosts5Data = new List<AccountItemVM>();

                        for (int i = 0; i < QualitativeAnalysis.Count; i++)
                        {
                            for (int j = 0; j < marketingCosts1.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(marketingCosts1[j]))
                                {
                                    marketingCosts1Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < marketingCosts2.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(marketingCosts2[j]))
                                {
                                    marketingCosts2Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < marketingCosts3.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(marketingCosts3[j]))
                                {
                                    marketingCosts3Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < marketingCosts4.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(marketingCosts4[j]))
                                {
                                    marketingCosts4Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < marketingCosts5.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(marketingCosts5[j]))
                                {
                                    marketingCosts5Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                        }

                        report.DataSources.Add(new ReportDataSource() { Name = "MarketingCosts1Data", Value = marketingCosts1Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "MarketingCosts2Data", Value = marketingCosts2Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "MarketingCosts3Data", Value = marketingCosts3Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "MarketingCosts4Data", Value = marketingCosts4Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "MarketingCosts5Data", Value = marketingCosts5Data });

                        decimal sumMarketingCosts = sumMarketingCosts1 + sumMarketingCosts2 + sumMarketingCosts3 + sumMarketingCosts4
                                                    + sumMarketingCosts5;

                        List<string> administrativeCosts1 = new List<string> { "381", "3811", "3812", "3813", "3814", "3815", "3816" };
                        decimal sumAdministrativeCosts1 = 0;
                        List<string> administrativeCosts2 = new List<string> { "382", "3821", "3822", "3823" };
                        decimal sumAdministrativeCosts2 = 0;
                        List<string> administrativeCosts3 = new List<string> { "383", "3831", "38311", "38312", "38314", "38315", "38316", "38317", "38318" };
                        decimal sumAdministrativeCosts3 = 0;
                        List<string> administrativeCosts4 = new List<string> { "3832", "38321", "38322" };
                        decimal sumAdministrativeCosts4 = 0;
                        List<string> administrativeCosts5 = new List<string> { "3833", "3834", "3835", "3835", "3836" };
                        decimal sumAdministrativeCosts5 = 0;

                        List<AccountItemVM> AdministrativeCosts1Data = new List<AccountItemVM>(),
                                            AdministrativeCosts2Data = new List<AccountItemVM>(),
                                            AdministrativeCosts3Data = new List<AccountItemVM>(),
                                            AdministrativeCosts4Data = new List<AccountItemVM>(),
                                            AdministrativeCosts5Data = new List<AccountItemVM>();

                        for (int i = 0; i < QualitativeAnalysis.Count; i++)
                        {
                            for (int j = 0; j < administrativeCosts1.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(administrativeCosts1[j]))
                                {
                                    AdministrativeCosts1Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < administrativeCosts2.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(administrativeCosts2[j]))
                                {
                                    AdministrativeCosts2Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < administrativeCosts3.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(administrativeCosts3[j]))
                                {
                                    AdministrativeCosts3Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < administrativeCosts4.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(administrativeCosts4[j]))
                                {
                                    AdministrativeCosts4Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                            for (int j = 0; j < administrativeCosts5.Count; j++)
                            {
                                if (QualitativeAnalysis[i].Code.Equals(administrativeCosts5[j]))
                                {
                                    AdministrativeCosts5Data.Add(QualitativeAnalysis[i]);
                                }
                            }
                        }

                        decimal sumAdministrativeCosts = sumAdministrativeCosts1 + sumAdministrativeCosts2 + sumAdministrativeCosts3
                                                        + sumAdministrativeCosts4 + sumAdministrativeCosts5;

                        report.DataSources.Add(new ReportDataSource() { Name = "AdministrativeCosts1Data", Value = AdministrativeCosts1Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "AdministrativeCosts2Data", Value = AdministrativeCosts2Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "AdministrativeCosts3Data", Value = AdministrativeCosts3Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "AdministrativeCosts4Data", Value = AdministrativeCosts4Data });
                        report.DataSources.Add(new ReportDataSource() { Name = "AdministrativeCosts5Data", Value = AdministrativeCosts5Data });
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

        public async Task<FiAccountBalancesVM> GetAccountBalances(FiAccountBalancesFilter filter)
        {
            List<FiEntryDetails> details = await _FiRepository.GetAccountBalances(filter);
            return new FiAccountBalancesVM()
            {
                TotalCredit = details.Sum(e => e.Credit),
                TotalDebit = details.Sum(e => e.Debit)
            };
        }
    }
}
