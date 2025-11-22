using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Security
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.Property(m => m.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Route)
                .HasMaxLength(200);

            builder.Property(m => m.Icon)
                .HasMaxLength(100);

            builder.HasOne(m => m.Parent)
                .WithMany(m => m.Children)
                .HasForeignKey(m => m.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}