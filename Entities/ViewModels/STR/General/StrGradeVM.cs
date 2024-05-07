using System.Collections.Generic;

namespace Entities.ViewModels.STR.General
{
    public class StrGradeGeneralVM
    {

        public string Name { get; set; }
        public int Code { get; set; }
        public int CommodityId { get; set; }
        public int TransactionUserId { get; set; }

        public int? AccountId { get; set; }





    }
    public class StrGradeVM : StrGradeGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrGradeGetVM : StrGradeVM
    {
        public string AccountName { get; set; }

        public string CommodityName { get; set; }
        public string CreateUserName { get; set; }
    }

    public class GradeWithPlatoonsVM : StrGradeVM
    {
        public List<StrPlatoonVM> Grade_Platoon { get; set; }


    }

}
