using System;
using System.Collections.Generic;
using System.Linq;
using musicstore.Data;
using musicstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace musicstore.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private ILogger _log;

        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> log)
        {
            _context = context;
            _log = log;
        }

        [HttpGet]
        public List<Product> Get()
        {
            _log.LogDebug("Getting the Product List");
            return _context.Product.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _log.LogDebug("Getting the product with id: {}", id);
            var product = _context.Product.SingleOrDefault(p => p.ID == id);

            return product == null ? (IActionResult) NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _log.LogDebug("Adding new Product");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(actionName: nameof(Get),
                routeValues: new {id = product.ID}, value: product);
        }
    }
}