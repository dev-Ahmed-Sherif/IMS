namespace Entities.ViewModels.TR.Instructor
{
    public class TrInstructorDataGeneralVM

    {
        public string Name { get; set; }

        public int Code { get; set; }


        public string phone { get; set; }


        public string Email { get; set; }


        public string Position { get; set; }


        public string Address { get; set; }


        public string Gender { get; set; }

        public int? CityId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class TrInstructorDataVM : TrInstructorDataGeneralVM

    {
        public int Id { get; set; }

    }
    public class TrInstructorDataGetVM : TrInstructorDataVM
    {
        public string CityName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

    }
}
