﻿using ProductandReviewAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductandReview.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
