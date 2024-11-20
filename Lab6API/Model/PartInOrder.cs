namespace Lab6API.Model
{
    public class PartInOrder
    {
        public int PartInOrderID { get; set; }
        public int OrderID { get; set; }
        public int PartSupplierID { get; set; }
        public decimal ActualSalesPrice { get; set; }
        public int Quantity { get; set; }

        public Order? Order { get; set; }
        public PartSupplier? PartSupplier { get; set; }
    }


}
