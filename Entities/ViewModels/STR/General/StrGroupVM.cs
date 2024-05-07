namespace Entities.ViewModels.STR.General
{
    public class StrGroupGeneralVM
    {

        public string Name { get; set; }
        public string Code { get; set; }
        public int PlatoonId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class StrGroupVM : StrGroupGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrGroupGetVM : StrGroupVM
    {
        public string PlatoonName { get; set; }
        public string CreateUserName { get; set; }
        public string GradeName { get; set; }
        public string CommodityName { get; set; }

        public int GradeId { get; set; }
        public int CommodityId { get; set; }
    }
}
