namespace Entities.ViewModels.PR
{
    public class PrUserModuleGeneralVM
    {

        public int UserId { get; set; }
        public int ModuleId { get; set; }
        public bool? IsAdmin { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class PrUserModuleVM : PrUserModuleGeneralVM
    {
        public int Id { get; set; }
    }
    public class PrUserModuleGetVM : PrUserModuleVM
    {

        //List of Role name and Role_Description
        public string UserName { get; set; }
        public string Module_Name { get; set; }
        public string Module_Description { get; set; }
    }

}
