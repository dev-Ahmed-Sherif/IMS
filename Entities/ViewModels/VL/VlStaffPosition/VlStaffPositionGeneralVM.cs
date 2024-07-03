using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.VL.VlStaffPosition
{
    public class VlStaffPositionGeneralVM:BaseViewModel
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
