using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public string GetProducts() {
            var x = 2;
            Console.Out.WriteLine(x);
            var y = 5;
            return (x*y).ToString();
        }


        [HttpGet("{id}")]
        public string GetProduct(int id) {
            return id.ToString();
        }
    }
}