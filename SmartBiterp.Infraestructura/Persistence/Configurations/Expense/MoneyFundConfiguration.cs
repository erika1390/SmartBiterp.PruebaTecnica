using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Expense
{
    public class MoneyFundConfiguration : IEntityTypeConfiguration<MoneyFund>
    {
        public void Configure(EntityTypeBuilder<MoneyFund> builder)
        {
            builder.ToTable("MoneyFunds");

            builder.Property(f => f.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(f => f.FundType)
                   .HasConversion<string>()
                   .IsRequired();
        }
    }
}
