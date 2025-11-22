using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartBiterp.Domain.Entities.Expense;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Infrastructure.Persistence.Configurations.Expense
{
    public class MoneyFundConfiguration : IEntityTypeConfiguration<MoneyFund>
    {
        public void Configure(EntityTypeBuilder<MoneyFund> builder)
        {
            builder.ToTable("MoneyFunds");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Code)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(f => f.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(f => f.FundType)
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(f => f.InitialBalance)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(f => f.CurrentBalance)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasMany(f => f.ExpenseHeaders)
                   .WithOne(e => e.MoneyFund)
                   .HasForeignKey(e => e.MoneyFundId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.Deposits)
                   .WithOne(d => d.MoneyFund)
                   .HasForeignKey(d => d.MoneyFundId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}