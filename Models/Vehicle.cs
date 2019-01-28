namespace RentCar.Models
{
    public class Vehicle
    {
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
    }
}