namespace Entities.ViewModels.STR.General
{
    public class StrItemGeneralVM
    {

        public string Name { get; set; }
        public string No { get; set; }
        public string FullCode { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public int CommodityId { get; set; }
        public int GradeId { get; set; }
        public int PlatoonId { get; set; }
        public int GroupId { get; set; }
        public int UnitId { get; set; }
        public int TransactionUserId { get; set; }




    }
    public class StrItemVM : StrItemGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrItemGetVM : StrItemVM
    {
        public string ReportDate { get; set; }
        public string PlatoonName { get; set; }
        public string CommodityName { get; set; }
        public string GradeName { get; set; }
        public string GroupName { get; set; }

        public string Platooncode { get; set; }
        public int Commoditycode { get; set; }
        public int Gradecode { get; set; }
        public string Groupcode { get; set; }

        public string UnitName { get; set; }
        public string CreateUserName { get; set; }
    }

    public class searchgeneral
    {
        public string Name { get; set; }
        public string FullCode { get; set; }
        public string Type { get; set; }
        public int? CommodityId { get; set; }
        public int? GradeId { get; set; }
        public int? PlatoonId { get; set; }
        public int? GroupId { get; set; }
        public int? UnitId { get; set; }

    }

    public class reportsearch : searchgeneral
    {
        public string reportName { get; set; }
        public string reportType { get; set; }

        //public List<StrItemGeneralVM> reportData { get; set; }

    }
}
