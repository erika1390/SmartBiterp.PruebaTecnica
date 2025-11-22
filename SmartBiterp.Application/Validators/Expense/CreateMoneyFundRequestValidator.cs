using FluentValidation;
using SmartBiterp.Application.DTOs.Expense;
using SmartBiterp.Domain.Enums;

namespace SmartBiterp.Application.Validators.Expense
{
    public class CreateMoneyFundRequestValidator : AbstractValidator<CreateMoneyFundRequest>
    {
        public CreateMoneyFundRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.FundType)
                .NotEmpty().WithMessage("FundType is required.")
                .Must(BeValidFundType)
                .WithMessage("FundType must be 'BankAccount' or 'CashBox'.");

            RuleFor(x => x.InitialBalance)
                .GreaterThanOrEqualTo(0)
                .WithMessage("InitialBalance must be equal or greater than 0.");
        }

        private bool BeValidFundType(string fundType)
        {
            return Enum.TryParse<MoneyFundType>(fundType, true, out _);
        }
    }
}