namespace Entities.ViewModels.Cc
{
    public class CcEquipmentGeneralVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int CostCenterId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcEquipmentVM : CcEquipmentGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcEquipmentGetVM : CcEquipmentVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CostCenterName { get; set; }
        public string CostCenterCode { get; set; }

    }
}
