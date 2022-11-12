using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;

namespace UI.Models;

public class OrderItemModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Name { get; set; }

    [Column(TypeName = "decimal(18,3)")]
    public decimal Quantity { get; set; }
    public string Unit { get; set; }

    public OrderItemModel(int id, int orderId, string name, decimal quantity, string unit)
    {
        Id = id;
        OrderId = orderId;
        Name = name;
        Quantity= quantity;
        Unit = unit;
    }

    public static OrderItem ToEntity(OrderItemModel obj)
    {
        return obj == null
            ? null
            : new OrderItem(obj.Id, obj.OrderId,obj.Name,obj.Quantity,obj.Unit);
    }

    public static OrderItemModel FromEntity(OrderItem obj)
    {
        return obj == null
            ? null
            : new OrderItemModel(obj.Id, obj.OrderId, obj.Name, obj.Quantity, obj.Unit);
    }

}
