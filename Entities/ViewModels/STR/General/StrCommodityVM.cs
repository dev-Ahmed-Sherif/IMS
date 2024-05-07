using System.Collections.Generic;

namespace Entities.ViewModels.STR.General
{
    public class StrCommodityGeneralVM
    {

        public string Name { get; set; }
        public int Code { get; set; }
        public int TransactionUserId { get; set; }
        public int? AccountId { get; set; }

    }
    public class StrCommodityVM : StrCommodityGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrCommodityGetVM : StrCommodityVM
    {

        public string CreateUserName { get; set; }
        public string AccountName { get; set; }
    }

    public class CommodityWithGradesVM : StrCommodityVM
    {
        public List<StrGradeVM> Commodity_Grade { get; set; }
    }

}
