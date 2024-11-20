using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class PartSupplier
    {
        public int PartSupplierID { get; set; }
        public int PartID { get; set; }
        public int SupplierID { get; set; }

        public Part? Part { get; set; }
        public Supplier? Supplier { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartInOrder> PartInOrders { get; set; } = new List<PartInOrder>();
    }
}
