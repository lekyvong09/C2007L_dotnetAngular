using System;
using API.Entities;

namespace API.dao
{
	public interface IBasketRepository
	{
		Task<CustomerBasket> GetBasketAsync(string basketId);
		Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
		Task<Boolean> DeleteBasketAsync(string basketId);
	}
}

