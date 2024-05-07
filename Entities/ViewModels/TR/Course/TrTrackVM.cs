namespace Entities.ViewModels.TR.Course
{
    public class TrTrackGeneralVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class TrTrackVM : TrTrackGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrTrackGetVM : TrTrackVM
    {
        public string CreateUserName { get; set; }
    }

}