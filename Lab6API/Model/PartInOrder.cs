namespace Lab6API.Model
{
    public class PartInOrder
    {
        public string PartInOrderID { get; set; }
        public string OrderID { get; set; }
        public string PartSupplierID { get; set; }
        public decimal ActualSalesPrice { get; set; }
        public int Quantity { get; set; }

        public Order? Order { get; set; }
        public PartSupplier? PartSupplier { get; set; }
    }


}
