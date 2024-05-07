namespace Entities.ViewModels.PY
{
    public class PyItemGroupGeneralVM
    {

        public string name { get; set; }

        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------
        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyItemGroupVM : PyItemGroupGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyItemGroupGetVM : PyItemGroupVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
