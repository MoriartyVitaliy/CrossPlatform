using System.Text.Json.Serialization;

namespace Lab6API.Model
{
    public class Part
    {
        public int PartID { get; set; }
        public int BrandID { get; set; }
        public int MainSupplierNr { get; set; }
        public int PartGroupID { get; set; }
        public int PartMakerCode { get; set; }
        public string PartName { get; set; }
        public string? MainSupplierName { get; set; }
        public decimal PriceToUs { get; set; }
        public decimal PriceToCustomer { get; set; }
        public string OtherPartDetails { get; set; }

        public PartGroup? PartGroup { get; set; }
        public Brand? Brand { get; set; }
        public Supplier? Supplier { get; set; }
        public PartMaker? PartMaker { get; set; }

        [JsonIgnore]
        public virtual ICollection<PartSupplier> PartSuppliers { get; set; } = new List<PartSupplier>();
        [JsonIgnore]
        public virtual ICollection<PartForCar> PartsForCars { get; set; } = new List<PartForCar>();
    }
}
