using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Security;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Security
{
    public class MenuRoleConfiguration : IEntityTypeConfiguration<MenuRole>
    {
        public void Configure(EntityTypeBuilder<MenuRole> builder)
        {
            builder.ToTable("MenuRoles");

            builder.HasKey(mr => mr.Id);

            builder.HasOne(mr => mr.Menu)
                .WithMany(m => m.MenuRoles)
                .HasForeignKey(mr => mr.MenuId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mr => mr.Role)
                .WithMany(r => r.MenuRoles)
                .HasForeignKey(mr => mr.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
