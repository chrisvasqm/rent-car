using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public byte StatusId { get; set; }

        public Status Status { get; set; }
    }
}