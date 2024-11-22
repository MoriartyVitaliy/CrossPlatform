using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Lab6API.Model
{
    public class Brand
    {
        [Key]
        public string BrandID { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string BrandDetails { get; set; }

        [JsonIgnore]
        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }

}
