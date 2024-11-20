namespace Lab6API.Model
{
    public class PartForCar
    {
        public int PartID { get; set; }
        public int CarID { get; set; }

        public Part? Part { get; set; }
        public Car? Car { get; set; }
    }

}
