using System;
using System.ComponentModel.DataAnnotations;
using RentCar.Views.Model;

namespace RentCar.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public bool HasScratches { get; set; }

        public byte FuelAmountId { get; set; }

        public FuelAmounts FuelAmount { get; set; }

        public bool HasReplacementTire { get; set; }

        public bool HasCatJack { get; set; }

        public bool HasBrokenGlass { get; set; }

        public bool IsFirstTireGood { get; set; }

        public bool IsSecondTireGood { get; set; }

        public bool IsThirdTireGood { get; set; }

        public bool IsFourthTireGood { get; set; }

        public DateTime CreatedAt { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Status")]
        public byte StatusId { get; set; }

        public Status Status { get; set; }
    }
}