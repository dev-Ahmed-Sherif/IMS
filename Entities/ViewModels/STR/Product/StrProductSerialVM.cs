using System;

namespace Entities.ViewModels.STR.Product
{
    public class StrProductSerialGeneralVM

    {
        public int Serial { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int TransactionUserId { get; set; }


        public int ProductId { get; set; }

    }

    public class StrProductSerialVM : StrProductSerialGeneralVM

    {
        public int Id { get; set; }


    }
    public class StrProductSerialGetVM : StrProductSerialVM

    {
        public string ProductName { get; set; }
        public string CreateUserName { get; set; }

    }

}
