using ProductandReviewAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductandReviewAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

    }


}
