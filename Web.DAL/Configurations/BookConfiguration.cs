using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.DAL.Models;

namespace Web.DAL.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnType("nvarchar(500)");
        
        builder.Property(b => b.AuthorId)
            .IsRequired();

        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);
        
        builder.HasData(
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Война и мир",
                PublishYear = 1869,
                AuthorId = Guid.Parse("9d650ba5-7dce-4d35-aedd-ffe78a67b5f1")
            },
            new Book
            {
                Id = Guid.NewGuid(),
                Title = "Преступление и наказание",
                PublishYear = 1866,
                AuthorId = Guid.Parse("075bee32-2334-4d14-8867-e348ec4fb419")
            }
        );
    }
}