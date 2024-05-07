namespace Entities.ViewModels
{
    public class HrDisciplinaryGeneralVM

    {
        public string name { get; set; }

        //Navigation foreign

        public int TransactionUserId { get; set; }
    }

    public class HrDisciplinaryVM : HrDisciplinaryGeneralVM
    {
        public int Id { get; set; }

    }

    public class HrDisciplinaryGetVM : HrDisciplinaryVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }


    }
}
