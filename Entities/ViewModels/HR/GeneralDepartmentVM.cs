namespace Entities.ViewModels
{
    public class GeneralDepartmentgeneralVM
    {

        public string Name { get; set; }
        public int TransactionUserId { get; set; }


    }
    public class GeneralDepartmentVM : GeneralDepartmentgeneralVM
    {
        public int Id { get; set; }
    }
    public class GeneralDepartmentGetVM : GeneralDepartmentVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
