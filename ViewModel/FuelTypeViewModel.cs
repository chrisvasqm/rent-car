using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class FuelTypeViewModel
    {
        public FuelTypeViewModel(FuelType fuelType)
        {
            Id = fuelType.Id;
            Description = fuelType.Description;
            StatusId = fuelType.StatusId;
            Status = fuelType.Status;
        }

        public int Id { get; set; }

        [Required] public string Description { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}