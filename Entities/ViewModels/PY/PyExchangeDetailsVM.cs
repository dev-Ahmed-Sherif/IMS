using System;

namespace Entities.ViewModels.PY
{
    public class PyExchangeDetailsGeneralVM
    {

        public string name { get; set; }
        public decimal Value { get; set; }

        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------
        public int ExChangeId { get; set; }       /*--{ Model => ExChange }++{ FK => ExChangeId }--*/
        public int EmployeeId { get; set; }       /*--{ Model => Employee }++{ FK => ExChangeId }--*/
        public int PyItemId { get; set; }         /*--{ Model => PyItem   }++{ FK => PyItemId   }--*/
        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyExchangeDetailsVM : PyExchangeDetailsGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyExchangeDetailsGetVM : PyExchangeDetailsVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string ExChangeName { get; set; }
        public string EmployeeName { get; set; }
        public string PyItemName { get; set; }

        //------------------------------------
        // Relation { Header Data  PyExchange } 
        //------------------------------------
        public string HeaderCreateUserName { get; set; }
        public string HeaderUpdateUserName { get; set; }
        public string HeaderName { get; set; }
        public int HeaderNo { get; set; }
        public DateTime HeaderDate { get; set; }
        public string HeaderDescription { get; set; }

    }

}
