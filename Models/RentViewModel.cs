using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using RentCar.Views.Model;

namespace RentCar.Models
{
    public class RentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }
        
        [Display(Name = "Date of rent")]
        public DateTime RentDate { get; set; }

        [Display(Name = "Date of return")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Price per day")]
        public int PricePerDay { get; set; }

        [Display(Name = "Number of days")]
        public int NumberOfDays { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Status")]
        public byte StatusId { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Status> Statuses { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }
        
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