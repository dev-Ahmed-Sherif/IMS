using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.VL
{
    [Index(nameof(BoardNo), nameof(ChassisNo), nameof(MotorNo), IsUnique = true)]
    public class VlViechle : EntityBaseNotes
    {
        public string BoardNo { get; set; }
        public string ChassisNo { get; set; }
        public string MotorNo { get; set; }
        public int Year { get; set; }
        public int ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public virtual VlManufacturer Manufacturer { get; set; }
        public int ModelId { get; set; }
        [ForeignKey(nameof(ModelId))]
        public virtual VlModel Model { get; set; }
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public virtual VlType Type { get; set; }
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual VlVehicleStatus VehicleStatus { get; set; }

    }
}
