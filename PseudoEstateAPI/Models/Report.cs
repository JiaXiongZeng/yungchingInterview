namespace PseudoEstateAPI.Models
{
    public class Report
    {
        public string? AgentId { get; set; }

        public string? AgentName { get; set; }

        public string? AgentTitle { get; set; }

        public string? AgentPhoneNo { get; set; }

        public string? AgentLicenses { get; set; }

        public string? OwnerId {  get; set; }

        public string? OwnerName { get; set; }

        public string? OwnerPhoneNo { get; set; }

        public string? OwnerEmail { get; set; }

        public string? EstateId { get; set; }

        public string? EstateDescription { get; set; }

        public string? BuildType { get; set; }

        public string? Address { get; set; }

        public double? SquareMeters { get; set; }

        public double? TotalPrice { get; set; }

        public string? Status { get; set; }

        public string? OnlineDtm { get; set; }
    }
}
