using Microsoft.EntityFrameworkCore;

namespace ProductandReviewAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }
    }
}
