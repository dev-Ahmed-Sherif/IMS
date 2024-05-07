namespace Entities.ViewModels.TR
{
    public class TrTraineeGeneralVM
    {



        //Navigation foreign


        public string Name { get; set; }
        public string Code { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string NationalId { get; set; }

        public int? CityId { get; set; }


        public int? CityStateId { get; set; }


        public int? CorporationCLientId { get; set; }

        public int TransactionUserId { get; set; }
    }

    public class TrTraineeVM : TrTraineeGeneralVM
    {
        public int Id { get; set; }

    }

    public class TrTraineeGetVM : TrTraineeVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string CorporationCLinetName { get; set; }

        public string CityName { get; set; }

    }
}
