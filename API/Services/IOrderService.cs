using System;
using API.Entities.Checkout;

namespace API.Services
{
	public interface IOrderService
	{
		Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress);
		Task<List<Order>> GetOrdersForUserAsync(string buyerEmail);
		Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
		Task<List<DeliveryMethod>> GetDeliveryMethodsAsync();
	}
}

