namespace Entities.ViewModels.Cc
{
    public class CcSourceGeneralVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? FunctionId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcSourceVM : CcSourceGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcSourceGetVM : CcSourceVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string FunctionName { get; set; }
        public int FunctionCode { get; set; }
    }
}
