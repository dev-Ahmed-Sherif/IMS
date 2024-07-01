namespace Entities.ViewModels.Pro
{
    public class ProTenderBiddingMethodGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProTenderBiddingMethodVM : ProTenderBiddingMethodGeneralVM
    {
        public int Id { get; set; }

    }
    public class ProTenderBiddingMethodGetVM : ProTenderBiddingMethodVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
