using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Precision(38,2)]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }


        /// Many-to-One relationship between Product & ProductType
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        /// Many-to-One relationship between Product & ProductBrand
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }

    }
}