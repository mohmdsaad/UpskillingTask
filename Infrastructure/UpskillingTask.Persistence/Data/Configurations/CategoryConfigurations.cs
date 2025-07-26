using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpskillingTask.Domain.Models;

namespace UpskillingTask.Persistence.Data.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                   .IsRequired();
            
            builder.Property(c => c.Description)
                   .IsRequired();
        }
    }
}
