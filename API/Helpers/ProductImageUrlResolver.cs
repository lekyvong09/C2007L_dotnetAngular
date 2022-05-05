using System;
using API.Dto;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
	public class ProductImageUrlResolver : IValueResolver<Product, ReturnProduct, string>
	{
		public ProductImageUrlResolver()
		{
		}

        public string Resolve(Product source, ReturnProduct destination, string destMember, ResolutionContext context)
        {
            return "https://localhost:5001/" + source.PictureUrl;
        }
    }
}

