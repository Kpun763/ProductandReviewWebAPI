
using ProductandReviewAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductandReviewAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
        public double AverageRating { get; set; }

    }
}
