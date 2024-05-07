namespace Entities.Helpers
{
    public static class ReportHelper
    {
        public static string GetReportDetails(string reportName, string reportType)
        {

            string outputFileName = reportType.ToUpper() switch
            {
                "EXCEL" => reportName + ".xls",
                "WORD" => reportName + ".doc",
                _ => reportName + ".pdf",
            };
            return outputFileName;
        }
    }

}
