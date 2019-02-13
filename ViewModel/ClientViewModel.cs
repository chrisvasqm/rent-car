using System.Collections;
using System.Collections.Generic;
using RentCar.Models;
using RentCar.Views.Model;

namespace RentCar.ViewModel
{
    public class ClientViewModel
    {
        public ClientViewModel(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            IdentificationCard = client.IdentificationCard;
            CreditCard = client.CreditCard;
            CreditLimit = client.CreditLimit;
            PersonTypeId = client.PersonTypeId;
            PersonType = client.PersonType;
            StatusId = client.StatusId;
            Status = client.Status;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string IdentificationCard { get; set; }

        public string CreditCard { get; set; }

        public double CreditLimit { get; set; }

        public byte PersonTypeId { get; set; }

        public PersonType PersonType { get; set; }

        public IEnumerable<PersonType> PersonTypes { get; set; }
        
        public byte StatusId { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}