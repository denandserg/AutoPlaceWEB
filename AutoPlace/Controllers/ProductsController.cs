using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloAngularApp.Models;

namespace HelloAngularApp.Controllers
{
	// Simple CRUD
    [Route("api/products")]
    public class ProductController : Controller
    {
        ApplicationContext db;
        public ProductController(ApplicationContext context)
        {
            db = context;
            if (!db.Cars.Any())
            {
                //db.Products.Add(new Product { Brend = "Nissan", Model = "Leaf", Cost = "23000" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return db.Cars.ToList();
        }

        [HttpGet("{id}")]
        public Car Get(int id)
        {
            Car product = db.Cars.FirstOrDefault(x => x.Id == id);
            return product;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Car product)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Car product)
        {
            if (ModelState.IsValid)
            {
                db.Update(product);
                db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Car product = db.Cars.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                db.Cars.Remove(product);
                db.SaveChanges();
            }
            return Ok(product);
        }
    }
}