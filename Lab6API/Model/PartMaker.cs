using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class PartMaker
    {
        public int PartMakerCode { get; set; }
        public string PartMakerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }

}
