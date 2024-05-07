namespace Entities.ViewModels.TR.General
{
    public class TrPurposeGeneralVM
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrPurposeVM : TrPurposeGeneralVM
    {
        public int Id { get; set; }


    }
    public class TrPurposeGetVM : TrPurposeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }



    }
}
