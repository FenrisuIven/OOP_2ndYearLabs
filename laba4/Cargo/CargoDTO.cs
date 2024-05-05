namespace laba4
{
    public class CargoDTO
    {
        public CropsDTO Crop { get; set; }
        public Delivery Delivery { get; set; }
        public int Amount { get; set; }
        public int PriceForOne { get; set; }
        
        public CargoDTO() {}
    }
}