namespace Entities.ViewModels.Cc
{


    public class CcRegionGeneralVM
    {

        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class CcRegionVM : CcRegionGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcRegionGetVM : CcRegionVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}

