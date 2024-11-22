namespace Lab6API.Model
{
    public class PartForCar
    {
        public string PartID { get; set; }
        public string CarID { get; set; }

        public Part? Part { get; set; }
        public Car? Car { get; set; }
    }

}
