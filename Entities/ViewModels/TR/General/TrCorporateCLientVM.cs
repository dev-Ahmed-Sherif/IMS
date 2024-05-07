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
}

