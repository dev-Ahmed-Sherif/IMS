using System;

namespace Entities.ViewModels.HR
{
    public class HrFinancialDegreeSalaryGeneralVM
    {

        public string name { get; set; }

        public int Salary { get; set; }
        public DateTime Date { get; set; }



        //Navigation foreign
        public int TransactionUserId { get; set; }
        public int FinancialDegreeId { get; set; }

    }

    public class HrFinancialDegreeSalaryVM : HrFinancialDegreeSalaryGeneralVM
    {
        public int Id { get; set; }

    }


    public class HrFinancialDegreeSalaryGetVM : HrFinancialDegreeSalaryVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

        public string FinancialDegreeName { get; set; }

    }
}
