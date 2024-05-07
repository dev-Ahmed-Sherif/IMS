using Entities.Models.Cc;
using Entities.Models.PR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Fa
{
    public class FaMoveFixedAsset : EntityBase
    {
        [StringLength(250)]
        public string Move_Type { get; set; }//نوع الحركة
        public int Move_No { get; set; }//رقم الحركة
        public string Description { get; set; }// تفاصسل
        public string Statement { get; set; }//البيان
        public int? Document_NO { get; set; }//رقم المستند
        public DateTime? Document_Date { get; set; }//تاريخ المستند
        public int Rate { get; set; }//نسبة اضافة او نقصان
        public int CostCenterId { get; set; }//مركز التكلفة
        public virtual CcCostCenter CostCenter { get; set; }
        public int ActivityId { get; set; }//البند الإحصائي
        public virtual CcActivity Activity { get; set; }
        public int FixedAssetId { get; set; }//بيانات الاصل
        public virtual FaFixedAsset FixedAsset { get; set; }

        // Relation { PrUser => FaMoveFixedAsset} +++ {View Model => TransactionUserId} 

        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
    }
}
