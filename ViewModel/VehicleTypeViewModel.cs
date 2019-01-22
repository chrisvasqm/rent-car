using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentCar.Models;

namespace RentCar.ViewModel
{
    public class VehicleTypeViewModel
    {
        public VehicleTypeViewModel()
        {
        }

        public VehicleTypeViewModel(VehicleType vehicleType)
        {
            Id = vehicleType.Id;
            Description = vehicleType.Description;
            StatusId = vehicleType.StatusId;
            Status = vehicleType.Status;
        }

        public int Id { get; set; }

        [Required] [StringLength(255)] public string Description { get; set; }

        [Display(Name = "Status")] public byte StatusId { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}