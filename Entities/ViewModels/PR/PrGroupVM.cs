namespace Entities.ViewModels.PR
{
    public class PrGroupGeneralVM
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class PrGroupVM : PrGroupGeneralVM
    {
        public int Id { get; set; }
    }
    //public class PrGroupWithGroupRoleVM : PrGroupVM
    //{
    //    //List of Group_Roles model
    //    public List<PrGroupWithGroupRoleVM> Group_Role { get; set; }
    //}
    public class PrGroupGetVM : PrGroupVM
    {
        public string CreateUserName { get; set; }
    }
    public class SectionGroup
    {
        public int sectionName { get; set; }
    }
}
