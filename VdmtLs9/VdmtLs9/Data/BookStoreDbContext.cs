using Microsoft.EntityFrameworkCore;
using VdmtLs9.Models;

namespace VdmtLs9.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
