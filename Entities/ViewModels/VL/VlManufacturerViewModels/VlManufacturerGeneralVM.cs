using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.VL.VlManufacturerViewModels
{
    public class VlManufacturerGeneralVM : BaseViewModel
    {
        [StringLength(30)]
        public string Name { get; set; }
    }
}
