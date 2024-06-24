using Entities.Models.HR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    public class VlVehicleJobOrder : EntityBaseNotes
    {
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public virtual VlViechle VLVehicle { get; set; }
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual VlStaff Driver { get; set; }
        public int SupervisorId { get; set; }
        [ForeignKey(nameof(SupervisorId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual VlStaff Supervisor { get; set; }
        public int GarageManagerId { get; set; }
        [ForeignKey(nameof(GarageManagerId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual VlStaff GarageManager { get; set; }
        public int ItineraryId { get; set; }
        [ForeignKey(nameof(ItineraryId))]
        public virtual VlItinerary Itinerary { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual HrEmployee Employee { get; set; }
        public string Companion { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int MeterStart { get; set; }
        public int MeterEnd { get; set; }
    }
}
