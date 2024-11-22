using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class PartMaker
    {
        public string PartMakerCode { get; set; }
        public string PartMakerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }

}
