using FluentValidation;

using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Validators.Expense
{
    public class CreateExpenseHeaderRequestValidator : AbstractValidator<CreateExpenseHeaderRequest>
    {
        public CreateExpenseHeaderRequestValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(x => x.MoneyFundId)
                .GreaterThan(0).WithMessage("MoneyFundId must be greater than zero.");

            RuleFor(x => x.StoreName)
                .NotEmpty().WithMessage("StoreName is required.")
                .MaximumLength(150);

            RuleFor(x => x.DocumentType)
                .IsInEnum().WithMessage("Invalid DocumentType value.");

            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("At least one detail is required.");
        }
    }
}