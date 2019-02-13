using System.ComponentModel.DataAnnotations;
using RentCar.Models;

namespace RentCar.Views.Model
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string IdentificationCard { get; set; }

        [Required]
        public string CreditCard { get; set; }

        [Required]
        public double CreditLimit { get; set; }

        public byte PersonTypeId { get; set; }

        public PersonType PersonType { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }
    }
}