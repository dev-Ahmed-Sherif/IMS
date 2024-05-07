namespace Entities.ViewModels.Cc
{
    public class CcPlantComponentGeneralVM
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcPlantComponentVM : CcPlantComponentGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcPlantComponentGetVM : CcPlantComponentVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
}
