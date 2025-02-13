namespace ClaimProcessor.DTOs
{
    public class DrugPriceDTO
    {
        public string Ndc {  get; set; }
        public string ConfirmationNumber { get; set; }
        public decimal Price { get; set; }
    }
}
