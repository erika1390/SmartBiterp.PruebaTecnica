using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Expense;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Expense
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder.ToTable("Deposits");

            builder.Property(d => d.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(d => d.Date)
                .IsRequired();

            builder.HasOne(d => d.MoneyFund)
                .WithMany(f => f.Deposits)
                .HasForeignKey(d => d.MoneyFundId);
        }
    }
}