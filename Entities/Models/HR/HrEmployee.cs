using Entities.Models.Cc;
using Entities.Models.PR;
using Entities.Models.SE;
using Entities.Models.STR.Add;
using Entities.Models.STR.Employee;
using Entities.Models.STR.WithDraw;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
//using Entities.Models.TR.Excuted;

namespace Entities.Models.HR
{
    public class HrEmployee : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }


        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(14)]
        public string National_Code { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Address { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public int InsuranceNumber { get; set; }
        //----------------------------------------------------------------------
        // Relation { PrUser => Account } +++ {View Model => TransactionUserId} 
        //----------------------------------------------------------------------
        public int QualificationId { get; set; }

        public virtual HrQualification Qualification { get; set; }

        public int QualificationLevelId { get; set; }

        public virtual HrQualificationLevel QualificationLevel { get; set; }
        public int SpecializationId { get; set; }
        public virtual HrSpecialization Specialization { get; set; }
        public DateTime QualificationDate { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime WorkingStateDate { get; set; }
        public int JobTitleId { get; set; }
        public virtual HrJobTitle JobTitle { get; set; }
        public int PositionId { get; set; }
        public virtual HrPosition Position { get; set; }
        public int MillitryStateId { get; set; }
        public virtual HrMillitryState MillitryState { get; set; }
        public int HiringTypeId { get; set; }
        public virtual HrHiringType HiringType { get; set; }
        public int FinancialDegreeId { get; set; }
        public virtual HrFinancialDegree FinancialDegree { get; set; }
        public DateTime FinancialDegreeDate { get; set; }
        public int CityStateId { get; set; }
        public virtual HrCityState CityState { get; set; }
        public int WorkPlaceId { get; set; }
        public virtual HrWorkPlace WorkPlace { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public string Gender { get; set; }
        public string MaritalState { get; set; }
        public int SeveranceReasonId { get; set; }
        public virtual HrSeveranceReason SeveranceReason { get; set; }
        public override int? CreatedByID { get; set; }
        public virtual PrUser CreatedBy { get; set; }
        public override int? UpdateByID { get; set; }
        public virtual PrUser UpdateBy { get; set; }
        public int? SectionId { get; set; }
        public int? CostCenterId { get; set; }
        public virtual CcCostCenter CostCenter { get; set; }
        public virtual ImsSection Section { get; set; }
        public int? BankId { get; set; }
        public virtual HrBank Bank { get; set; }
        public int? PayMethodId { get; set; }
        public virtual HrPayMethod PayMethod { get; set; }
        public int? SalaryStatusId { get; set; }
        public virtual HrSalaryStatus SalaryStatus { get; set; }
        public string Religion { get; set; }

        public virtual ICollection<StrAdd> STR_Add { get; set; }
        public virtual ICollection<StrEmployeeOpeningCustody> STR_Employee_Opening_Custody { get; set; }
        public virtual ICollection<StrEmployeeExchange> STR_Employee_Exchange { get; set; }
        public virtual ICollection<StrEmployeeExchange> Dest_Employee_Exchange { get; set; }
        public virtual ICollection<HrEmployeeVacation> abs_employee { get; set; }
        public virtual ICollection<HrEmployeeVacation> SubstituteEmpolyee { get; set; }
        public virtual ICollection<StrWithDraw> STR_Withdraw { get; set; }
        public virtual ICollection<HrEmployeeFinancialDegree> HrEmployeeFinancialDegree_employee { get; set; }
        [AllowNull]
        public int? UserId { get; set; }
        public virtual PrUser User { get; set; }
        //public List<TrExcuted> TrExcutedDelegate { get; set; }
        //public List<TrExcutedTrainee> TrExcutedTrainee { get; set; }
    }
}
