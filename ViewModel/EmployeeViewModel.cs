using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentCar.Models;

namespace RentCar.Views.Model
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            IdentificationCard = employee.IdentificationCard;
            WorkShiftId = employee.WorkShiftId;
            WorkShift = employee.WorkShift;
            CommissionId = employee.CommissionId;
            Commission = employee.Commission;
            AdmissionDate = employee.AdmissionDate;
            StatusId = employee.StatusId;
            Status = employee.Status;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string IdentificationCard { get; set; }

        [Display(Name = "Work shift")]
        public byte WorkShiftId { get; set; }

        public WorkShift WorkShift { get; set; }

        public IEnumerable<WorkShift> WorkShifts { get; set; }

        [Display(Name = "Commission %")]
        public byte CommissionId { get; set; }

        public Commission Commission { get; set; }

        public IEnumerable<Commission> Commissions { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        public DateTime AdmissionDate { get; set; }

        [Display(Name = "Status")]
        public byte StatusId { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}