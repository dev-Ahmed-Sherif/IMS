using Entities.Models.PR;

namespace Entities.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public int ModuleId { get; set; }
        public virtual PrModule Module { get; set; }
    }
}
