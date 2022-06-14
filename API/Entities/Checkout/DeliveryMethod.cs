using System;
using Microsoft.EntityFrameworkCore;

namespace API.Entities.Checkout
{
	public class DeliveryMethod
	{
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }

        [Precision(38, 2)]
        public decimal Price { get; set; }
    }
}

