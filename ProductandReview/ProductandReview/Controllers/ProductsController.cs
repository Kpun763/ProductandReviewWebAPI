using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductandReviewAPI.Data;
using ProductandReviewAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductandReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/<ProductsC>/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Reviews)
                .SingleOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            double? averageRating = product.Reviews?.Average(r => r.Rating);

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Reviews = product.Reviews?.Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    Text = r.Text,
                    Rating = r.Rating
                }).ToList(),
                AverageRating = averageRating.HasValue ? averageRating.Value : 0
            };
            return Ok(productDTO);
        }
        //GET: api/<Products>
        [HttpGet]
        public IActionResult GetAllProducts([FromQuery] double? maxPrice = null)
        {
            IQueryable<Product> query = _context.Products;
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price < maxPrice);
            }

            var products = query.ToList();

            return Ok(products);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            if (newProduct == null) return BadRequest();
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var existingProduct = _context.Products.Find(id);
            if (existingProduct == null)
                return NotFound();
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Reviews = updatedProduct.Reviews;
            _context.SaveChanges();
            return Ok(existingProduct);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var productToDelete = _context.Products.Find(id);
            if (productToDelete == null)
                return NotFound();

            _context.Products.Remove(productToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
