using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5.ViewModels
{
    public class CustomerStatusViewModels
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }

}
