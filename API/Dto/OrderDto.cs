﻿using System;
namespace API.Dto
{
	public class OrderDto
	{
		public string BasketId { get; set; }
		public int DeliveryMethodId { get; set; }
		public AddressDto ShipToAddress { get; set; }
	}
}

