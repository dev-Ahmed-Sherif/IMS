using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProType
{
    public class ProTypeOutputVM : BaseViewModel
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
