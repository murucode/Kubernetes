using Microsoft.EntityFrameworkCore;

namespace MyWeatherForecast.Database {

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
      { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
  }
}