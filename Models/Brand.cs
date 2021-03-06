using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required] 
        public string Description { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }
    }
}