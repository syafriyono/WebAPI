using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
            new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        //getAll
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //getById
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                //return NotFound();
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(product);
        }

        public IEnumerable<Product> getByCategory(string category)
        {
            return products.Where((p) => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }
    } 
}
