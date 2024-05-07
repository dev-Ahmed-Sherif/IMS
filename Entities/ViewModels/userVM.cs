using System.Collections.Generic;

namespace Entities.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserModule> Modules { get; set; }
        public string AccessToken { get; set; }
        public int? EmployeeId { get; set; }
        public int? SectionId { get; set; }
    }
    public class UserModule
    {
        public int id { get; set; }
        public string name { get; set; }

        //public bool? IsAdmin { get; set; }
        public List<UserRole>? roles { get; set; }
    }
    public class UserRole
    {
        public int id { get; set; }
        public string name { get; set; }
        // public string? engname { get; set; }
    }
    //public class UserSection
    //{
    //    public string? SectionName { get; set; }
    //}
}
