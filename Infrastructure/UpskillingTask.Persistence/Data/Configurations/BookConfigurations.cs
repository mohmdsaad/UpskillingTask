using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpskillingTask.Domain.Models;

namespace UpskillingTask.Persistence.Data.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b=>b.Name)
                   .IsRequired();

            builder.Property(b => b.Price)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();
            
            builder.Property(p => p.Stock)
                   .IsRequired();

            #region (Books - Category) Relationship
            builder.HasOne(b => b.Category)
                       .WithMany(c => c.Books)
                       .HasForeignKey(b => b.CategoryId);
            #endregion
        }
    }
}