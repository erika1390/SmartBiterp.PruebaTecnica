using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Expense
{
    public class ExpenseDetailConfiguration : IEntityTypeConfiguration<ExpenseDetail>
    {
        public void Configure(EntityTypeBuilder<ExpenseDetail> builder)
        {
            builder.ToTable("ExpenseDetails");

            builder.Property(d => d.Amount)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(d => d.ExpenseType)
                .WithMany(t => t.ExpenseDetails)
                .HasForeignKey(d => d.ExpenseTypeId);
        }
    }
}