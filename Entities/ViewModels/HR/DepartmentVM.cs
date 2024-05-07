using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class DepartmentGeneralVM
    {
        [StringLength(100)]
        [Required(ErrorMessage = "enter department name")]
        public string Name { get; set; }
        public int GeneralDepartmentId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class DepartmentVM : DepartmentGeneralVM
    {
        public int Id { get; set; }

    }
    public class DepartmentGetVM : DepartmentVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string GeneralDepartmentName { get; set; }
    }
}
