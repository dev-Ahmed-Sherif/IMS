using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.Pro.ProTenderSellerReqSendTypeViewModels
{
    public class ProTenderSellerReqSendTypeGeneralVM : BaseViewModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
