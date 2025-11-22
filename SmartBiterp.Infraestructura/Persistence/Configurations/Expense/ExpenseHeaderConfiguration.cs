using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Expense
{
    public class ExpenseHeaderConfiguration : IEntityTypeConfiguration<ExpenseHeader>
    {
        public void Configure(EntityTypeBuilder<ExpenseHeader> builder)
        {
            builder.ToTable("ExpenseHeaders");

            builder.Property(e => e.StoreName)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(e => e.DocumentType)
                   .HasConversion<string>()
                   .IsRequired();

            builder.HasMany(e => e.Details)
                   .WithOne(d => d.ExpenseHeader)
                   .HasForeignKey(d => d.ExpenseHeaderId);
        }
    }
}
