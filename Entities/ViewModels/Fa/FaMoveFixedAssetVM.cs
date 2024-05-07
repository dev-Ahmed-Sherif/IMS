
using System;
using System.ComponentModel.DataAnnotations;


namespace Entities.ViewModels.Fa
{
    public class FaMoveFixedAssetGeneralVM
    {

        public string Move_Type { get; set; }//نوع الحركة
        public int Move_No { get; set; }//رقم الحركة
        public string? Description { get; set; }// تفاصسل
        public string? Statement { get; set; }//البيان
        public int? Document_NO { get; set; }//رقم المستند
        public DateTime? Document_Date { get; set; }//تاريخ المستند
        public int Rate { get; set; }//نسبة اضافة او نقصان
        public int CostCenterId { get; set; }//مركز التكلفة

        public int FixedAssetId { get; set; }//بيانات الاصل
        public int ActivityId { get; set; }//البند الإحصائي
        public int TransactionUserId { get; set; }
    }
    public class FaMoveFixedAssetVM : FaMoveFixedAssetGeneralVM
    {
        public int Id { get; set; }
    }
    public class FaMoveFixedAssetGetVM : FaMoveFixedAssetVM
    {
        public string CostCenterName { get; set; }
        public string FixedAssetName { get; set; }
        public string ActivityName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
    }
    public class SearchGeneralMove
    {
        public string? Move_Type { get; set; }//نوع الحركة
        public int? Move_No { get; set; }//رقم الحركة
        public string? Description { get; set; }// تفاصسل
        public string? Statement { get; set; }//البيان
        public int? Document_NO { get; set; }//رقم المستند
        [DataType(DataType.Date)]
        public DateTime? Document_Date { get; set; }//تاريخ المستند
        public int? Rate { get; set; }//نسبة اضافة او نقصان
        public int? CostCenterId { get; set; }//مركز التكلفة

        public int? FixedAssetId { get; set; }//بيانات الاصل
        public int? ActivityId { get; set; }//البند الإحصائي



    }

    public class reportsearchMove : SearchGeneralMove
    {
        public string reportName { get; set; }
        public string reportType { get; set; }

    }
}



