using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Expense
{
    public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.ToTable("ExpenseTypes");

            builder.Property(e => e.Code)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(e => e.Description)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }
}