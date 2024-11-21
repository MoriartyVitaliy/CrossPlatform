using System.Text.Json.Serialization;

namespace Lab5.ViewModels
{
    public class CustomerViewModels
    {
        public string CustomerID { get; set; }
        public int StatusCode { get; set; }
        public string IndividualOrOrganisation { get; set; }
        public string OrganisationName { get; set; }
        public string IndividualFirstName { get; set; }
        public string IndividualMiddleName { get; set; }
        public string IndividualLastName { get; set; }
        public string OtherDetails { get; set; }
        public CustomerStatusViewModels CustomerStatus { get; set; }
    }

}
