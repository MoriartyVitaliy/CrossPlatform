using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Supplier
    {
        public int SupplierNr { get; set; }
        public string SupplierName { get; set; }
        public string StreetAddress { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string OtherDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartSupplier> PartSuppliers { get; set; } = new List<PartSupplier>();
        [JsonIgnore]
        public virtual ICollection<Part> SuppliedParts { get; set; } = new List<Part>();
    }

}
