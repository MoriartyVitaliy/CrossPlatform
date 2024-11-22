using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Order
    {
        public string OrderID { get; set; } = Guid.NewGuid().ToString();
        public string CustomerID { get; set; }
        public decimal OrderAmountDue { get; set; }
        public string OtherDetails { get; set; }

        public Customer? Customer { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartInOrder> PartsInOrders { get; set; } = new List<PartInOrder>();
    }
}
