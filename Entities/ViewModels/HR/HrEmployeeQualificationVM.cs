using System;

namespace Entities.ViewModels
{
    public class HrEmployeeQualificationGeneralVM
    {

        public DateTime Date { get; set; }
        public string Attachment { get; set; }

        //Navigation foreign
        public int QualificationId { get; set; }
        public int QualificationLevelId { get; set; }
        public int SpecializationId { get; set; }
        public int EmployeeId { get; set; }
        public int TransactionUserId { get; set; }
    }

    public class HrEmployeeQualificationVM : HrEmployeeQualificationGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrEmployeeQualificationGetVM : HrEmployeeQualificationVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string QualificationName { get; set; }
        public string QualificationLeveName { get; set; }
        public string SpecializationName { get; set; }
        public string EmployeeName { get; set; }

    }
}
