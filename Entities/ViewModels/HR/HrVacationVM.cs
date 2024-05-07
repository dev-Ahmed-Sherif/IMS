namespace Entities.ViewModels.HR
{
    public class HrVacationGeneralVM
    {

        public string name { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class HrVacationVM : HrVacationGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrVacationGetVM : HrVacationVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
