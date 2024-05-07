namespace Entities.ViewModels.PY
{
    public class PyTaxBracketGeneralVM
    {

        public decimal Value { get; set; }
        public decimal Ratio { get; set; }

        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------
        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyTaxBracketVM : PyTaxBracketGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyTaxBracketGetVM : PyTaxBracketVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }


    }
}
