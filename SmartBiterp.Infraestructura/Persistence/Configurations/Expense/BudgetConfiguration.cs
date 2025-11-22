using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Expense
{
    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.ToTable("Budgets");

            builder.Property(b => b.AllocatedAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.Month)
                .IsRequired();

            builder.Property(b => b.Year)
                .IsRequired();

            builder.HasOne(b => b.ExpenseType)
                .WithMany(t => t.Budgets)
                .HasForeignKey(b => b.ExpenseTypeId);
        }
    }
}
