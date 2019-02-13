using RentCar.Models;

namespace RentCar.Views.Model
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IdentificationCard { get; set; }

        public string CreditCard { get; set; }

        public double CreditLimit { get; set; }

        public byte PersonTypeId { get; set; }

        public PersonType PersonType { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }
    }
}