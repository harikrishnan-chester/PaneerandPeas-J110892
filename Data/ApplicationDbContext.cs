using Microsoft.EntityFrameworkCore;

namespace PaneerandPeas_J110892.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FoodItem> FoodItem { get; set; }
    }

    
}
