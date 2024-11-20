using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Car
    {
        public int CarID { get; set; }
        public int CarManufacturerNr { get; set; }
        public int CarYearOfManufacture { get; set; }
        public string CarModel { get; set; }
        public string OtherCarDetails { get; set; }

        public CarManufacturer? CarManufacturer { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartForCar> PartsForCars { get; set; } = new List<PartForCar>();
    }

}
