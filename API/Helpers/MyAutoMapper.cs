using System;
using API.Dto;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
	public class MyAutoMapper : Profile
	{
		public MyAutoMapper()
		{
			CreateMap<Product, ReturnProduct>()
				.ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
				.ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
				.ForMember(d => d.PictureUrl, o => o.MapFrom<ProductImageUrlResolver>());

			CreateMap<AddressDto, Entities.Checkout.Address>();

			/// bi-directional mapping
			CreateMap<CustomerBasketDto, CustomerBasket>();
			CreateMap<BasketItemDto, BasketItem>();

			CreateMap<Entities.Identity.Address, AddressDto>().ReverseMap();
		}
	}
}

