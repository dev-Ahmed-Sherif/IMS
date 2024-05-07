using System;

namespace Entities.ViewModels.HR
{
    public class HrEmployeeFinancialDegreeGeneralVM
    {


        public int FinancialDegreeId { get; set; }
        public int TransactionUserId { get; set; }
        public DateTime FinancialDegreeDate { get; set; }
    }

    public class HrEmployeeFinancialDegreeVM : HrEmployeeFinancialDegreeGeneralVM
    {

        public int Id { get; set; }
    }


    public class HrEmployeeFinancialDegreeGetVM : HrEmployeeFinancialDegreeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string FinancialDegreeName { get; set; }
    }
}
