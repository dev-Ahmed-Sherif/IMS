using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ReportViewModels
{
    public class Part1ViewModel
    {
        public int Num { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal NetBasedOnDebit { get; set; }
        public decimal Stale { get; set; }
        public decimal Net { get; set; }
        public decimal OpeningValue { get; set; }
    }
}
