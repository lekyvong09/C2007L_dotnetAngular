using System;
using API.Dto;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
	public class ProductImageUrlResolver : IValueResolver<Product, ReturnProduct, string>
	{
        /// IConfiguration is used to get environment variables
        private IConfiguration _config;

        public ProductImageUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ReturnProduct destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                string baseUrl = _config["ApiUrl"];

                return baseUrl + source.PictureUrl;
            }
            return null;
        }
    }
}

