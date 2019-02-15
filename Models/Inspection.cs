using System;
using RentCar.Views.Model;

namespace RentCar.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public bool HasScratches { get; set; }

        public byte FuelAmountId { get; set; }

        public FuelAmount FuelAmount { get; set; }

        public bool HasReplacementTire { get; set; }

        public bool HasCatJack { get; set; }

        public bool HasBrokenGlass { get; set; }

        public bool IsFirstTireGood { get; set; }

        public bool IsSecondTireGood { get; set; }

        public bool IsThirdTireGood { get; set; }

        public bool IsFourthTireGood { get; set; }

        public DateTime CreatedAt { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }
    }
}