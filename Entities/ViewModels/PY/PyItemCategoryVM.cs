namespace Entities.ViewModels.PY
{
    public class PyItemCategoryGeneralVM
    {

        public string name { get; set; }

        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------

        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyItemCategoryVM : PyItemCategoryGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyItemCategoryGetVM : PyItemCategoryVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }


    }
}
