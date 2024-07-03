using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.VL.VlDrivierLicenseTypeViewModels
{
   public class VlDrivierLicenseTypeGeneralVM
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
