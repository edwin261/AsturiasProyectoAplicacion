using DocumentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DocumentList> DocumentLists { get; set; }
        public DbSet<DocumentItem> Documents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}