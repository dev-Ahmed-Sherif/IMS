namespace Entities.ViewModels.Cc
{
    public class CcCostCenterGeneralVM
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public int FunctionId { get; set; }
        public int SourceId { get; set; }

        public int RegionId { get; set; }

        public int SubRegionId { get; set; }

        public int PlantId { get; set; }

        public int PlantComponentId { get; set; }

        public int ActivityId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class CcCostCenterVM : CcCostCenterGeneralVM
    {
        public int Id { get; set; }
    }
    public class CcCostCenterGetVM : CcCostCenterVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string FunctionName { get; set; }
        public int FunctionCode { get; set; }
        public string SourceName { get; set; }
        public string SourceCode { get; set; }
        public string RegionName { get; set; }
        public int RegionCode { get; set; }
        public string SubRegionName { get; set; }
        public int SubRegionCode { get; set; }
        public string PlantName { get; set; }
        public int PlantCode { get; set; }
        public string PlantComponentName { get; set; }
        public int PlantComponentCode { get; set; }
        public string ActivityName { get; set; }
        public string ActivityCode { get; set; }

    }
}
