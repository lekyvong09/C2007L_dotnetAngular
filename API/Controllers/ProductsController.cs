using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.dao;
using API.Data;
using API.Dto;
using API.Entities;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<ProductBrand> _productBrandRepository;
        private IGenericRepository<ProductType> _productTypeRepository;
        private IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PageList<ReturnProduct>>> GetProducts(
                [FromQuery]ProductRequestParams productRequestParams,
                [FromQuery]PaginationParams pagination) {
            GenericSpecification<Product> specification = new GenericSpecification<Product>(
                x =>
                    (string.IsNullOrEmpty(productRequestParams.Search) || x.Name.ToLower().Contains(productRequestParams.Search))
                    && (!productRequestParams.BrandId.HasValue || x.ProductBrandId == productRequestParams.BrandId)
                    && (!productRequestParams.TypeId.HasValue || x.ProductTypeId == productRequestParams.TypeId)
            );

            /// get total records for Pagination apply apply condition where but before apply Pagination
            int totalRecord = await _productRepository.CountAsync(specification);

            specification.AddIncludes(x => x.ProductType);
            specification.AddIncludes(x => x.ProductBrand);
            specification.ApplyPagination((pagination.PageNumber - 1) * pagination.PageSize, pagination.PageSize);

            if (productRequestParams.Sort != null)
            {
                switch (productRequestParams.Sort)
                {
                    case "priceAsc":
                        specification.AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        specification.AddOrderByDesc(x => x.Price);
                        break;
                    default:
                        specification.AddOrderBy(x => x.Price);
                        break;
                }
            }
            else
            {
                specification.AddOrderBy(x => x.Price);
            }


            List<Product> products = await _productRepository.GetEntityListWithSpec(specification);
            List<ReturnProduct> returnData = _mapper.Map<List<Product>, List<ReturnProduct>>(products);

            var endResult = new PageList<ReturnProduct>(returnData, pagination.PageNumber, pagination.PageSize, totalRecord);

            return Ok(endResult);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnProduct>> GetProduct(int id) {
            GenericSpecification<Product> specification = new GenericSpecification<Product>(criteria => criteria.Id == id);
            specification.AddIncludes(x => x.ProductType);
            specification.AddIncludes(x => x.ProductBrand);

            Product product = await _productRepository.GetEntityWithSpec(specification);
            return Ok(_mapper.Map<Product, ReturnProduct>(product));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands() {
            return await _productBrandRepository.GetAllAsync();
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes() {
            return await _productTypeRepository.GetAllAsync();
        }
        
    }
}