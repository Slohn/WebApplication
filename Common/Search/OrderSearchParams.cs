namespace Common.Search
{
    public class OrderSearchParams
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ProviderId { get; set; }
        public string Number { get; set; }
    }
}