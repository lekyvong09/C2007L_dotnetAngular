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
			CreateMap<Product, ReturnProduct>();
		}
	}
}

