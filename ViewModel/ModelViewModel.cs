using System.Collections.Generic;
using RentCar.Models;

namespace RentCar.ViewModel
{
    public class ModelViewModel
    {
        public ModelViewModel()
        {
        }

        public ModelViewModel(Model model)
        {
            Id = model.Id;
            ModelId = model.ModelId;
            Description = model.Description;
            StatusId = model.StatusId;
            Status = model.Status;
        }

        public int Id { get; set; }

        public int ModelId { get; set; }

        public string Description { get; set; }

        public byte StatusId { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Status> Statuses { get; set; }
    }
}