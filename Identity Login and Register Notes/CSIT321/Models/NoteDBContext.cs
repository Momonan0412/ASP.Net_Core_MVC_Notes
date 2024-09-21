using Microsoft.EntityFrameworkCore;

namespace CSIT321.Models
{
    public class NoteDBContext : DbContext
    {
        public NoteDBContext(DbContextOptions<NoteDBContext> options) : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; } // Creates the model's table
    }
}
