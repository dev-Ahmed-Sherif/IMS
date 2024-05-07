using System;

namespace Entities.ViewModels.STR.General
{


    public class StrFiscalYearGeneralVM
    {

        public string fiscalyear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class StrFiscalYearVM : StrFiscalYearGeneralVM
    {
        public int Id { get; set; }
    }
    public class FiscalYearGetVM : StrFiscalYearVM
    {

        public string CreateUserName { get; set; }
    }
    public class FiscalYearData
    {
        public int Id { get; set; }
        public string FiscalYear { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
