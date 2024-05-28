using Entities.ViewModels.TR.Course;

namespace Entities.ViewModels.TR.General
{
    public class TrCorporateCLientGeneralVM
    {
        public string Name { get; set; }

        public int Code { get; set; }

        public string phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public int? CityId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class TrCorporateCLientVM : TrCorporateCLientGeneralVM

    {
        public int Id { get; set; }

    }
    public class TrCorporateCLientGetVM : TrCorporateCLientVM
    {
        public string CityName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
    public class TrCorporateCLientGetSearchVM : TrCorporateCLientGetVM
    {
        public string ReportDate { get; set; }
        public string Section { get; set; }

    }
    public class TrCorporateCLientSearch
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string? CityId { get; set; }
        public string CityName { get; set; }
        public string TransactionUserId { get; set; }

        //public string CreateUserName { get; set; }
        //public string UpdateUserName { get; set; }

    }
    public class TrCorporateCLientReport : TrCorporateCLientSearch
    {
        public string reportName { get; set; }
        public string reportType { get; set; }
    }

}

