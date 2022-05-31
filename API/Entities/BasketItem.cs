using System;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
	public class BasketItem
	{
        public int Id { get; set; }
        public string ProductName { get; set; }

        [Precision(38, 2)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }
    }
}

