using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.HR
{
    public class HrBank : EntityBase
    {
        [StringLength(100)]
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
