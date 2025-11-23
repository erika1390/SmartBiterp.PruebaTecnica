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
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.DocumentType)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(e => e.MoneyFund)
                .WithMany(f => f.ExpenseHeaders)
                .HasForeignKey(e => e.MoneyFundId);

            builder.HasMany(e => e.Details)
                .WithOne(d => d.ExpenseHeader)
                .HasForeignKey(d => d.ExpenseHeaderId);

            builder.HasMany(h => h.Details)
               .WithOne(d => d.ExpenseHeader)
               .HasForeignKey(d => d.ExpenseHeaderId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}