namespace Entities.ViewModels.TR.General
{
    public class TrBudgetGeneralVM
    {
        public int? NoTrainee { get; set; }
        public int? NoHour { get; set; }
        public decimal? InstructorHourFee { get; set; }
        public decimal? InstructorTotalFee { get; set; }
        public decimal? SuperVisingFee { get; set; }
        public decimal? OtherFee { get; set; }
        public decimal? SalaryTotal { get; set; }
        public decimal? SuppliesCost { get; set; }
        public decimal? TransportCost { get; set; }
        public decimal? ServiceTotal { get; set; }
        public decimal? CourseTotal { get; set; }
        public int? CourseId { get; set; }
        public int TransactionUserId { get; set; }
    }
    public class TrBudgetVM : TrBudgetGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrBudgetGetVM : TrBudgetVM
    {
        public string CourseName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }


    }



}
