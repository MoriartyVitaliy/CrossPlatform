using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class CustomerStatus
    {
        [Key]
        public int StatusCode { get; set; }
        [Required]
        public string StatusDescription { get; set; }
        [JsonIgnore]
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }

}
