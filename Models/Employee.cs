using System;
using System.ComponentModel.DataAnnotations;
using RentCar.Models;

namespace RentCar.Views.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IdentificationCard { get; set; }

        public byte WorkShiftId { get; set; }

        public WorkShift WorkShift { get; set; }

        public byte CommissionId { get; set; }

        public Commission Commission { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime AdmissionDate { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }
    }
}