using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }

        [Column(TypeName = "DateTime2(7)")]
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }

        public Order(int id, string number, DateTime date, int providerId)
        {
            Id =id;
            Number = number;
            Date = date;
            ProviderId = providerId;
        }
    }
}
