using Microsoft.EntityFrameworkCore;
using Web.DAL.Configurations;
using Web.DAL.Models;

namespace Web.DAL.Context;

public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
{
    public DbSet<Author>  Authors { get; set; }
    public DbSet<Book>  Books { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }
}