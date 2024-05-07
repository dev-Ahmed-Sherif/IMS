namespace Entities.ViewModels.PY
{
    public class PyItemGroupEmployeeGeneralVM
    {
        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------
        public int EmployeeId { get; set; }       /*--{ Model => Employee }++{ FK => EmployeeId }--*/
        public int ItemGroupId { get; set; }
        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyItemGroupEmployeeVM : PyItemGroupEmployeeGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyItemGroupEmployeeGetVM : PyItemGroupEmployeeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string EmployeeName { get; set; }
        public string PyItemGroupName { get; set; }
        public string HeaderCreateUserName { get; set; }

    }
}
