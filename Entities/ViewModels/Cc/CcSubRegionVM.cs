namespace Entities.ViewModels.Cc
{

    public class CcSubRegionGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int? RegionId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcSubRegionVM : CcSubRegionGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcSubRegionGetVM : CcSubRegionVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string RegionName { get; set; }
        public int RegionCode { get; set; }

    }

}
