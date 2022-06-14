using System;
using API.dao;
using API.Entities;
using API.Entities.Checkout;

namespace API.Services
{
	public class OrderService : IOrderService
	{
        //private IGenericRepository<Order> _orderRepository;
        //private IGenericRepository<DeliveryMethod> _deliveryMethodRepository;
        //private IGenericRepository<Product> _productRepository;
        private IUnitOfWork _unitOfWork;
        private IBasketRepository _basketRepository;

        public OrderService(IUnitOfWork unitOfWork,
                            IBasketRepository basketRepository)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            IGenericRepository<Product> productRepository = _unitOfWork.CreateGenericRepository<Product>();
            IGenericRepository<DeliveryMethod> deliveryMethodRepository = _unitOfWork.CreateGenericRepository<DeliveryMethod>();
            IGenericRepository<Order> orderRepository = _unitOfWork.CreateGenericRepository<Order>();

            CustomerBasket basket = await _basketRepository.GetBasketAsync(basketId);

            /// we don't trust product info which we receive from client, therefore we get data from database
            List<OrderItem> items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                Product productItem = await productRepository.GetByIdAsync(item.Id);
                OrderItem orderItem = new OrderItem(productItem.Id, productItem.Name, productItem.PictureUrl, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            DeliveryMethod deliveryMethod = await deliveryMethodRepository.GetByIdAsync(deliveryMethodId);

            decimal subtotal = items.Sum(item => item.Price * item.Quantity);

            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);

            orderRepository.Add(order);

            /// Unit Of Work: commit all or rollback if one transaction is failed
            var result = await _unitOfWork.Complete();

            if (result <= 0)
                return null;

            await _basketRepository.DeleteBasketAsync(basketId);

            return order;
        }

        public Task<List<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}

