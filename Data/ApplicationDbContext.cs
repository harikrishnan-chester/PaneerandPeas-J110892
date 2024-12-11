using Microsoft.EntityFrameworkCore;

namespace PaneerandPeas_J110892.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the menu item
        public string Description { get; set; } // Description of the menu item
        public decimal Price { get; set; } // Price of the menu item
    }
}



}
