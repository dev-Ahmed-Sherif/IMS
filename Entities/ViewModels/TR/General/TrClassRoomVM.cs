namespace Entities.ViewModels.TR
{
    public class TrClassRoomGeneralVM
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public bool IsActive { get; set; }
        public int CityStateId { get; set; }
        public int TrainingCenterId { get; set; }

        public int TransactionUserId { get; set; }
    }
    public class TrClassRoomVM : TrClassRoomGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrClassRoomGetVM : TrClassRoomVM
    {
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }

        public string CityStateName { get; set; }
        public string TrainingCenterName { get; set; }

    }
}
