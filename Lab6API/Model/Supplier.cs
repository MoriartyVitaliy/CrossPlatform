using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Supplier
    {
        [Key]
        public string SupplierNr { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string SupplierName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string OtherDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartSupplier> PartSuppliers { get; set; } = new List<PartSupplier>();
        [JsonIgnore]
        public virtual ICollection<Part> SuppliedParts { get; set; } = new List<Part>();
    }

}
