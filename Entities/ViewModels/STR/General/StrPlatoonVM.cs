using System.Collections.Generic;

namespace Entities.ViewModels.STR.General
{
    public class StrPlatoonGeneralVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int GradeId { get; set; }
        public int TransactionUserId { get; set; }


    }
    public class StrPlatoonVM : StrPlatoonGeneralVM
    {
        public int Id { get; set; }

    }
    public class StrPlatoonGetVM : StrPlatoonVM
    {
        public string GradeName { get; set; }
        public string CreateUserName { get; set; }
        public string CommodityName { get; set; }
        public int CommodityId { get; set; }

    }

    public class PlatoonWithGroupsVM : StrPlatoonVM
    {
        public List<StrGroupVM> Platoon_Group { get; set; }
    }

}
