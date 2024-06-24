using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.VL.VlGarageViewModels
{
    public class VlGarageGeneralVM : BaseViewModel
    {
        [StringLength(30)]
        public string Name { get; set; }
    }
}
