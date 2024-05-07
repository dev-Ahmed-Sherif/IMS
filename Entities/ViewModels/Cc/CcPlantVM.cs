namespace Entities.ViewModels.Cc
{
    public class CcPlantGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int? SubRegionId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcPlantVM : CcPlantGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcPlantGetVM : CcPlantVM
    {

        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string SubRegionName { get; set; }
        public int SubRegionCode { get; set; }
    }

}
