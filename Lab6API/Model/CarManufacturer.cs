using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class CarManufacturer
    {
        [Key]
        public string CarManufacturerNr { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string CarManufacturerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }

}
