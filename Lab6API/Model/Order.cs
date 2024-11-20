using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public decimal OrderAmountDue { get; set; }
        public string OtherDetails { get; set; }

        public Customer? Customer { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartInOrder> PartsInOrders { get; set; } = new List<PartInOrder>();
    }
}
