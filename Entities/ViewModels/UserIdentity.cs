using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class UserIdentity
    {
        public UserIdentity(int id, string name, int? employeeId = null, int? sectionId = null)
        {
            Id = id;
            EmployeeId = employeeId;
            SectionId = sectionId;
            Name = name;

        }
        public UserIdentity(string userIdString, string name, string employeeIdString = null, string sectionIdString = null)
        {
            if (int.TryParse(userIdString, out int userId))
            {
                Id = userId;
            };
            if (int.TryParse(employeeIdString, out int employeeId))
            {
                EmployeeId = employeeId;
            };
            if (int.TryParse(sectionIdString, out int sectionId))
            {
                SectionId = sectionId;
            };
            Name = name;
        }

        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? SectionId { get; set; }
        public string Name { get; set; }
    }
}
