using Microsoft.AspNetCore.Mvc;
using ProductandReviewAPI.Data;
using ProductandReviewAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductandReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<Reviews>
        [HttpGet]
        public IActionResult GetAllReviews()
        {
           var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }

        // GET api/<Reviews>/5
        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
                return NotFound();

            return Ok(review);
        }

        //GET api/<Reviews>/ByProductId/{productId}
        [HttpGet("ByProductId/{productId}")]
        public IActionResult GetByProductId(int ProductId) 
        {
            var reviews = _context.Reviews.Where(r => r.ProductId == ProductId).ToList();
            return Ok(reviews);
        }



        // POST api/<Reviews>
        [HttpPost]
        public IActionResult AddReview([FromBody] Review newReview)
        {
            if (newReview == null) return BadRequest();
            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetReview), new {id = newReview.Id}, newReview);
        }

        // PUT api/<Reviews>/5
        [HttpPut("{id}")]
        public IActionResult UpdateReview(int id, [FromBody] Review updatedReview)
        {
            var existingReview = _context.Reviews.Find(id);
            if (existingReview == null)
                return NotFound();
            
            existingReview.Text = updatedReview.Text;
            existingReview.Rating = updatedReview.Rating;
            existingReview.ProductId = updatedReview.ProductId;
            _context.SaveChanges();
            return Ok(existingReview);
        }

        // DELETE api/<Reviews>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            var reviewToDelete = _context.Reviews.Find(id);
            if (reviewToDelete == null) 
                return NotFound();

            _context.Reviews.Remove(reviewToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
