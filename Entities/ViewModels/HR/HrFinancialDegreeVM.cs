namespace Entities.ViewModels.HR
{
    public class HrFinancialDegreeGeneralVM
    {


        public string name { get; set; }
        public int NoYear { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class HrFinancialDegreeVM : HrFinancialDegreeGeneralVM
    {

        public int Id { get; set; }

    }
    public class HrFinancialDegreeGetVM : HrFinancialDegreeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

}
