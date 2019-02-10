using System.Collections.Generic;

namespace RentCar.Models
{
    public class VehicleViewModel
    {
        public VehicleViewModel(Vehicle vehicle)
        {
            Id = vehicle.Id;
            Description = vehicle.Description;
            ChassisNumber = vehicle.ChassisNumber;
            MotorNumber = vehicle.MotorNumber;
            LicensePlate = vehicle.LicensePlate;
            VehicleTypeId = vehicle.VehicleTypeId;
            VehicleType = vehicle.VehicleType;
            BrandId = vehicle.BrandId;
            Brand = vehicle.Brand;
            ModelId = vehicle.ModelId;
            Model = vehicle.Model;
            FuelTypeId = vehicle.FuelTypeId;
            FuelType = vehicle.FuelType;
            StatusId = vehicle.StatusId;
            Status = vehicle.Status;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string ChassisNumber { get; set; }

        public string MotorNumber { get; set; }

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

        public IEnumerable<Status> Statuses { get; set; }
    }
}