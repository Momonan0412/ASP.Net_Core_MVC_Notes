using FirstWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; } // Categories Table
    }
}
