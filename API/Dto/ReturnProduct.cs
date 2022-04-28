using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Dto
{
    public class ReturnProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Precision(38,2)]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}