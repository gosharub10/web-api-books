using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.DAL.Models;

namespace Web.DAL.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        
        builder.HasKey(x => x.Id);

        builder.Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnType("nvarchar(200)");

        builder.HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);
        
        builder.HasData(
            new Author
            {
                Id = Guid.Parse("9d650ba5-7dce-4d35-aedd-ffe78a67b5f1"),
                Name = "Лев Толстой",
                DateOfBirth = new DateTime(1828, 9, 9)
            },
            new Author
            {
                Id = Guid.Parse("075bee32-2334-4d14-8867-e348ec4fb419"),
                Name = "Фёдор Достоевский",
                DateOfBirth = new DateTime(1821, 11, 11)
            }
        );
    }
}