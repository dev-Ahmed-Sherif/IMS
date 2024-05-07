namespace Entities.ViewModels.Cc
{
    public class CcFunctionGeneralVM
    {

        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcFunctionVM : CcFunctionGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcFunctionGetVM : CcFunctionVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
