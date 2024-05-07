namespace Entities.ViewModels.HR
{
    public class HrSeveranceReasongeneralVM
    {


        public string name { get; set; }

        public int TransactionUserId { get; set; }
    }

    public class HrSeveranceReasonVM : HrSeveranceReasongeneralVM
    {
        public int Id { get; set; }
    }

    public class HrSeveranceReasonGetVM : HrSeveranceReasonVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

}
