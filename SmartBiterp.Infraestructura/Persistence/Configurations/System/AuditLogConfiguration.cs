using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.System;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.System
{
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable("AuditLogs");

            builder.Property(a => a.User)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Action)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Entity)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.RecordId)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Detail)
                .HasMaxLength(500);
        }
    }
}
