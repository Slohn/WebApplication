using Entities;

namespace UI.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }

        public string ProviderName { get; set; }

        public OrderModel() { }
        public OrderModel(int id, string number, DateTime date, int providerId, string providerName)
        {
            Id = id;
            Number = number;
            Date = date;
            ProviderId = providerId;
            ProviderName = providerName;
        }

        public static Order ToEntity(OrderModel obj)
        {
            return obj == null
                ? null
                : new Order(obj.Id, obj.Number, obj.Date,obj.ProviderId);
        }

        public static OrderModel FromEntity(Order obj)
        {
            return obj == null
                ? null
                : new OrderModel(obj.Id, obj.Number, obj.Date, obj.ProviderId, obj.ProviderName);
        }
    }
}
