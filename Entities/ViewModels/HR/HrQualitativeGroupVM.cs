namespace Entities.ViewModels.HR
{
    public class HrQualitativeGroupGeneralVM
    {


        public string name { get; set; }
        public int TransactionUserId { get; set; }

    }

    public class HrQualitativeGroupVM : HrQualitativeGroupGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrQualitativeGroupGetVM : HrQualitativeGroupVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }

}
