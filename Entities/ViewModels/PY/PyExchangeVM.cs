using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.PY
{
    public class PyExchangeGeneralVM
    {

        public string Name { get; set; }
        public int No { get; set; }
        public int FiscalYearId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        //---------------------------
        // Relation { Foreign Key  } 
        //---------------------------
        public int TransactionUserId { get; set; }/*--{ Model => PrUser }++{ FK => TransactionUserId }--*/
    }

    public class PyExchangeVM : PyExchangeGeneralVM
    {
        public int Id { get; set; }

    }

    public class PyExchangeGetVM : PyExchangeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string FiscalYear { get; set; }
    }
    public class search
    {
        public int? No { get; set; }
        public int? fiscalyearId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
