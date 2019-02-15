using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [Display(Name = "Chassis number")]
        public string ChassisNumber { get; set; }

        [Display(Name = "Motor number")]
        public string MotorNumber { get; set; }

        [Display(Name = "License plate")]
        public string LicensePlate { get; set; }

        public byte VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }

        public byte BrandId { get; set; }

        public Brand Brand { get; set; }

        public byte ModelId { get; set; }

        public Model Model { get; set; }

        public byte FuelTypeId { get; set; }

        public FuelType FuelType { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }

        public bool IsRented { get; set; }
    }
}