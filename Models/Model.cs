namespace RentCar.Models
{
    public class Model
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public string Description { get; set; }
        
        public byte StatusId { get; set; }
        
        public Status Status { get; set; }
    }
}