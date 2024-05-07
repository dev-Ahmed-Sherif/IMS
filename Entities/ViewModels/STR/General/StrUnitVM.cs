namespace Entities.ViewModels.STR.General
{
    public class StrUnitGeneralVM

    {

        public string Name { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class StrUnitVM : StrUnitGeneralVM
    {
        public int Id { get; set; }
    }
    public class StrUnitGetVM : StrUnitVM
    {
        public string CreateUserName { get; set; }
    }

}