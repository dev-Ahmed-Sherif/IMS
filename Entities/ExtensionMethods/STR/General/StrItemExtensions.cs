using Entities.Models.STR.General;
using Entities.ViewModels.STR.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExtensionMethods.STR.General
{
    public static class StrItemExtensions
    {
        public static StrItemGetVM ToStrItemGetVM(this StrItem p)
        {
            return new StrItemGetVM
            {
                Id = p.Id,
                Name = p.Name,
                No = p.No,
                FullCode = p.FullCode,
                IsActive = p.IsActive,
                Type = p.Type,
                CommodityId = p.CommodityId,
                CommodityName = p.STR_Commodity.Name,
                Commoditycode = p.STR_Commodity.Code,
                Gradecode = p.STR_Grade.Code,
                GradeName = p.STR_Grade.Name,
                Platooncode = p.STR_Platoon.Code,
                PlatoonName = p.STR_Platoon.Name,
                Groupcode = p.STR_Group.Code,
                GroupName = p.STR_Group.Name,
                UnitName = p.STR_Unit.Name,
                GradeId = p.GradeId,
                PlatoonId = p.PlatoonId,
                GroupId = p.GroupId,
                UnitId = p.UnitId,
                TransactionUserId = p.CreatedBy.Id,
               // ReportDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt")
            };
        }
    }
}
