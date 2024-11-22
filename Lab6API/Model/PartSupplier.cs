using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class PartSupplier
    {
        public string PartSupplierID { get; set; }
        public string PartID { get; set; }
        public string SupplierID { get; set; }

        public Part? Part { get; set; }
        public Supplier? Supplier { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartInOrder> PartInOrders { get; set; }
    }
}
