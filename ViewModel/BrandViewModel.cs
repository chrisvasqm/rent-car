using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class BrandViewModel
    {
        public BrandViewModel()
        {
        }

        public BrandViewModel(Brand brand)
        {
            Id = brand.Id;
            Description = brand.Description;
            Status = brand.Status;
        }
        
        public int Id { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }
        
        [Display(Name = "Status")]
        public byte StatusId { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}