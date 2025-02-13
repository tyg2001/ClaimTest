namespace ClaimProcessor.DTOs
{
    public class ClaimDTO
    {
        public long Id { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberDOB { get; set; }
        public string NDC { get; set; }
        public string PlanName { get; set; }
        public decimal PlanRate { get; set; }
        public DateTime DOS { get; set; }
        
    }
}
