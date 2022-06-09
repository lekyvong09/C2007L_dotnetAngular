using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private ApplicationDbContext _context;

        public BuggyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            Product notfoundProduct = _context.Products.Find(1000);
            if (notfoundProduct == null)
            {
                return NotFound(new ErrorResponse(404, "test not found on buggy controller"));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            Product notfoundProduct = _context.Products.Find(1000);
            if (notfoundProduct == null)
            {
                Console.Out.WriteLine(notfoundProduct.ToString()); /// this will create server exception
            }

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ErrorResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }


        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
    }
}
