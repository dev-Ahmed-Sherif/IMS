namespace Entities.ViewModels.PY
{
    public class PyItemGroupDetailsGeneralVM
    {
        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------
        public int PyItemId { get; set; }         /*--{ Model => PyItem }++{ FK => PyItemId }--*/
        public int ItemGroupId { get; set; }
        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyItemGroupDetailsVM : PyItemGroupDetailsGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyItemGroupDetailsGetVM : PyItemGroupDetailsVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string PyItemName { get; set; }
        public string PyItemGroupName { get; set; }
        public string HeaderCreateUserName { get; set; }
    }
}

