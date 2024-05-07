namespace Entities.ViewModels.HR
{
    public class HrQualificationGeneralVM
    {


        public string name { get; set; }

        //Navigation foreign
        public int QualitativeGroupId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class HrQualificationVM : HrQualificationGeneralVM
    {
        public int Id { get; set; }
    }
    public class HrQualificationGetVM : HrQualificationVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string QualitativeGroupName { get; set; }
    }

}
