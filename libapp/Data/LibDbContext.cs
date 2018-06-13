using Microsoft.EntityFrameworkCore;
using libapp.Data.Model;

namespace libapp.Data
{
  public class LibDbContext : DbContext
  {
    public LibDbContext(DbContextOptions<LibDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<Book> Books {get; set;}
  }
}