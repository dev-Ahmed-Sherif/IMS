namespace Entities.ViewModels.PY
{
    public class PyItemGeneralVM
    {

        public string name { get; set; }
        public string Manner { get; set; }
        public string Type { get; set; }
        public string CalcType { get; set; }
        public string Status { get; set; }
        public string Party { get; set; }
        public string ResetType { get; set; }
        public string Equation { get; set; }

        public int Round { get; set; }
        public int Code { get; set; }

        public decimal Value { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public decimal ResetValue { get; set; }

        public bool Visibility { get; set; }
        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------
        public int CategoryId { get; set; }       /*--{ Model => PyItemCategory }++{ FK => CategoryId }--*/
        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyItemVM : PyItemGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyItemGetVM : PyItemVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CategoryName { get; set; }
        public string HeaderCreateUserName { get; set; }

    }
}
