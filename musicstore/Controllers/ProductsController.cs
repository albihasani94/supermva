using System;
using System.Collections.Generic;
using System.Linq;
using musicstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace musicstore.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product>(new[]
            {
                new Product() {ID = 1, Name = "Test"},
                new Product() {ID = 2, Name = "_test2"}
            }
        );

        [HttpGet]
        public List<Product> Get()
        {
            return _products;
        }

        [HttpGet("{id}")] // capture route parameter
        public IActionResult Get(int id)
        {
            var product = _products.SingleOrDefault(p => p.ID == id);

            return product == null ? (IActionResult) this.NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
//            if (product == null) throw new ArgumentNullException(nameof(product));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _products.Add(product);
            return CreatedAtAction(actionName: nameof(Get),
                routeValues: new {id = product.ID}, value: product);
        }
    }
}