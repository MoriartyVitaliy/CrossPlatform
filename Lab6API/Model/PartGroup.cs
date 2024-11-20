using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class PartGroup
    {
        public int PartGroupID { get; set; } // Уникальный идентификатор группы
        public string PartGroupName { get; set; } // Название группы
        [JsonIgnore]
        public virtual ICollection<Part> Parts { get; set; } // Коллекция деталей, входящих в эту группу
    }
}
