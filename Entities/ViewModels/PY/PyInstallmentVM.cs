using System;

namespace Entities.ViewModels.PY
{
    public class PyInstallmentGeneralVM
    {
        public int No { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Value { get; set; }
        public decimal InstallmentValue { get; set; }
        public int InstallmentNo { get; set; }
        public decimal PaiedSum { get; set; }

        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------
        public int EmployeeId { get; set; }       /*--{ Model => Employee }++{ FK => EmployeeId }--*/
        public int PyItemId { get; set; }         /*--{ Model => PyItem }++{ FK => PyItemId }--*/
        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyInstallmentVM : PyInstallmentGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyInstallmentGetVM : PyInstallmentVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmployeeName { get; set; }
        public string PyItemName { get; set; }

    }
}
