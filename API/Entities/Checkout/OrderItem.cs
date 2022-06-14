using System;
using Microsoft.EntityFrameworkCore;

namespace API.Entities.Checkout
{
	public class OrderItem
	{
        public int Id { get; set; }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }

        [Precision(38, 2)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public OrderItem() { }
        public OrderItem(int productItemId, string productName, string pictureUrl, decimal price, int quantity)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
            Quantity = quantity;
        }
    }
}

