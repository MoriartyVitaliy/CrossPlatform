using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandDetails { get; set; }

        [JsonIgnore]
        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }

}
