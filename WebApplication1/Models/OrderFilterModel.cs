namespace UI.Models
{
    public class OrderFilterModel
    {
        public int? ProviderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? OtderItemId { get; set; }
        public string Unit { get; set; }
    }
}
