using System;
using System.Collections.Generic;
using System.Linq;
using musicstore.Data;
using musicstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace musicstore.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _context.Product.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Product.SingleOrDefault(p => p.ID == id);

            return product == null ? (IActionResult) this.NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(actionName: nameof(Get),
                routeValues: new {id = product.ID}, value: product);
        }
    }
}