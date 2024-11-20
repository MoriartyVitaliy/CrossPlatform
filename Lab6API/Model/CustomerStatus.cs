using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class CustomerStatus
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        [JsonIgnore]
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }

}
