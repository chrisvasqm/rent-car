using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentCar.Models;
using RentCar.Views.Model;

namespace RentCar.ViewModel
{
    public class InspectionViewModel
    {
        public InspectionViewModel(Inspection inspection)
        {
            Id = inspection.Id;
            VehicleId = inspection.VehicleId;
            Vehicle = inspection.Vehicle;
            ClientId = inspection.ClientId;
            Client = inspection.Client;
            HasScratches = inspection.HasScratches;
            FuelAmountId = inspection.FuelAmountId;
            FuelAmount = inspection.FuelAmount;
            HasReplacementTire = inspection.HasReplacementTire;
            HasCatJack = inspection.HasCatJack;
            HasBrokenGlass = inspection.HasBrokenGlass;
            IsFirstTireGood = inspection.IsFirstTireGood;
            IsSecondTireGood = inspection.IsSecondTireGood;
            IsThirdTireGood = inspection.IsThirdTireGood;
            IsFourthTireGood = inspection.IsFourthTireGood;
            CreatedAt = inspection.CreatedAt;
            EmployeeId = inspection.EmployeeId;
            Employee = inspection.Employee;
            StatusId = inspection.StatusId;
            Status = inspection.Status;
        }
        
        public int Id { get; set; }

        [Display(Name = "Vehicle")]

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }

        [Display(Name = "Client")]

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        public bool HasScratches { get; set; }

        public byte FuelAmountId { get; set; }

        public FuelAmounts FuelAmount { get; set; }

        public IEnumerable<FuelAmounts> FuelAmountses { get; set; }

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

        public IEnumerable<Employee> Employees { get; set; }

        [Display(Name = "Status")]

        public byte StatusId { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}