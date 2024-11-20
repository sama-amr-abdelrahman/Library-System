using Library_System.Models;
using Microsoft.EntityFrameworkCore;
namespace Library_System.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AuthorModel> Author { get; set; }
        public DbSet<BookModel> Book { get; set; }
        public DbSet<GenreModel> Genre { get; set; }
        public DbSet<IdentityCard> IdentityCard { get; set; }
        public DbSet<CreditCard> CreditCard { get; set;}
    }
}
