namespace _2.Backend.DTOs
{
    public class BeerUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public decimal AlcoholPercentage { get; set; }
    }
}
