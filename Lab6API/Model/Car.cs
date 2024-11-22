using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Car
    {
        [JsonIgnore]
        public string CarID { get; set; } = Guid.NewGuid().ToString();
        public string CarManufacturerNr { get; set; }
        public int CarYearOfManufacture { get; set; }
        public string CarModel { get; set; }
        public string OtherCarDetails { get; set; }

        public CarManufacturer? CarManufacturer { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartForCar> PartsForCars { get; set; }
    }

}
