using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using RentCar.Views.Model;

namespace RentCar.Models
{
    public class RentViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int PricePerDay { get; set; }

        public int NumberOfDays { get; set; }

        public string Comment { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }
        
        public RentViewModel(Rent rent)
        {
            Id = rent.Id;
            EmployeeId = rent.EmployeeId;
            Employee = rent.Employee;
            VehicleId = rent.VehicleId;
            Vehicle = rent.Vehicle;
            ClientId = rent.ClientId;
            Client = rent.Client;
            RentDate = rent.RentDate;
            ReturnDate = rent.ReturnDate;
            PricePerDay = rent.PricePerDay;
            NumberOfDays = rent.NumberOfDays;
            Comment = rent.Comment;
            StatusId = rent.StatusId;
            Status = rent.Status;
        }
        
    }
}