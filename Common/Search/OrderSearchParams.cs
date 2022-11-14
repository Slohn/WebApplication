namespace Common.Search
{
    public class OrderSearchParams
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ProviderId { get; set; }
        public int? OrderItemId { get; set; }
        public string Number { get; set; }
        public int? ObjectsCount { get; set; }
        public int? StartIndex { get; set; }
        public string Unit { get; set; }
    }
}