using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Customer
    {
        public string CustomerID { get; set; } = Guid.NewGuid().ToString();
        public int StatusCode { get; set; }
        public string IndividualOrOrganisation { get; set; }
        public string OrganisationName { get; set; }
        public string IndividualFirstName { get; set; }
        public string IndividualMiddleName { get; set; }
        public string IndividualLastName { get; set; }
        public string OtherDetails { get; set; }

        public CustomerStatus? CustomerStatus { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
