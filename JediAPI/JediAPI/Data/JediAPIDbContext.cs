using JediAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JediAPI.Data
{
    public class JediAPIDbContext : DbContext
    {
        public JediAPIDbContext(DbContextOptions options): base(options)
        {

        }

        // Act as tables for entity framework core
        public DbSet<JediNote> JediNotes { get; set; }
    }
}
