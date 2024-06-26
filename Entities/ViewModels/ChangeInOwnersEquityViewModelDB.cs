using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class ChangeInOwnersEquityViewModelDB
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Opening_BasedOnDebit { get; set; }
        public decimal NetBasedOnDebit { get; set; }

    }
}
