namespace Entities.ViewModels.Pro
{
    public class ProPlantTypeGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class ProPlanTypeVM : ProPlantTypeGeneralVM
    {
        public int Id { get; set; }
    }
    public class ProPlantTypeGetVM : ProPlanTypeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
