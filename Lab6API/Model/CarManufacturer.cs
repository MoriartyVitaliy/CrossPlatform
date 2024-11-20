using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class CarManufacturer
    {
        public int CarManufacturerNr { get; set; }
        public string CarManufacturerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }

}
