using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels.TR.Course
{
    public class TrTrackDetailsGeneralVM
    {
        public int? CourseId { get; set; }
        public int? TrackId { get; set; }
        public int TransactionUserId { get; set; }

    }
    public class TrTrackDetailsVM : TrTrackDetailsGeneralVM
    {
        public int Id { get; set; }

    }
    public class TrTrackDetailsGetVM : TrTrackDetailsVM
    {
        public string CourseName { get; set; }
        //public string TrackName { get; set; }
        public string CreateUserName { get; set; }
        public string UpdateUserName { get; set; }
        public string HeaderName { get; set; }
        public string HeaderDescription { get; set; }
        public decimal HeaderPrice { get; set; }
    }
    public class search
    {
        public int? TrackId { get; set; }
        public int? CourseId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
