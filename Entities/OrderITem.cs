using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }
        public string Unit { get; set; }

        public OrderItem() { }

        public OrderItem(int id, int orderId, string name, decimal quantity, string unit) 
        {
            Id = id;
            OrderId = orderId;
            Name = name;
            Unit = unit;
            Quantity = quantity;
        }

    }
}
