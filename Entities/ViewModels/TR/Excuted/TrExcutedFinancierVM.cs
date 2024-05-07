namespace Entities.ViewModels.TR.Excuted
{
    public class TrExcutedFinancierGeneralVM
    {
        public int ExcutedId { get; set; }

        public int FinancierId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrExcutedFinancierVM : TrExcutedFinancierGeneralVM
    {
        public int Id { get; set; }


    }
    public class TrExcutedFinancierGetVM : TrExcutedFinancierVM
    {
        public string FinancierName { get; set; }



        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }


    }
}
