using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.Base.Models;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product {
                Id = 1,
                Title = "IPhone",
                Price = 300
            },
            new Product {
                Id = 2,
                Title = "Macbook",
                Price = 500
            }
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = Products.Find(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public IActionResult InsertProduct([FromBody] Product product)
        {
            Products.Insert(Products.Count, product);
            return Created($"Created Product {product.Id}",product);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            var record = Products.Find(x => x.Id == product.Id);
            if(record == null)
            {
                return NotFound();
            }
            else
            {
                record.Price = product.Price;
                record.Title = product.Title;
                return Ok(record);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProductPatch(int id,[FromBody] JsonPatchDocument<Product> document)
        {
            var product = Products.Find(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                document.ApplyTo(product,ModelState);
                return Ok(product);
            }
        }

        [HttpDelete()]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            var record = Products.Find(x => x.Id == id);
            Products.Remove(record);
            return Ok(true);
        }
    }
}
