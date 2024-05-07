namespace Entities.ViewModels.STR.General
{
    public class StrApprovalStatusGeneralVM
    {

        public string name { get; set; }
        public int TransactionUserId { get; set; }

    }

    public class StrApprovalStatusVM : StrApprovalStatusGeneralVM
    {
        public int Id { get; set; }

    }


    public class StrApprovalStatusGetVM : StrApprovalStatusVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
