using System;
using Microsoft.EntityFrameworkCore;

namespace API.Entities.Checkout
{
	public class Order
	{
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; } /// One Order can have many OrderItems
        public string BuyerEmail { get; set; }  /// we want to separate Order from Identity
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }

        [Precision(38, 2)]
        public decimal Subtotal { get; set; }
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;
        public string PaymentIntentId { get; set; }

        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

        public Order() { }
        public Order(List<OrderItem> orderItems, string buyerEmail, Address shipToAddress, DeliveryMethod deliveryMethod, decimal subtotal)
        {
            OrderItems = orderItems;
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            Subtotal = subtotal;
        }
    }
}

