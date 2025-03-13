namespace _2.Backend.DTOs
{
    public class BeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public decimal AlcoholPercentage { get; set; }
    }
}
