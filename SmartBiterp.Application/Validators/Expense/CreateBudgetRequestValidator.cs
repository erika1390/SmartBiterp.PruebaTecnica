using FluentValidation;

using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Validators.Expense
{
    public class CreateBudgetRequestValidator : AbstractValidator<CreateBudgetRequest>
    {
        public CreateBudgetRequestValidator()
        {
            RuleFor(x => x.ExpenseTypeId)
                .GreaterThan(0)
                .WithMessage("ExpenseTypeId must be greater than zero.");

            RuleFor(x => x.Year)
                .InclusiveBetween(2000, 2100)
                .WithMessage("Year must be between 2000 and 2100.");

            RuleFor(x => x.Month)
                .InclusiveBetween(1, 12)
                .WithMessage("Month must be between 1 and 12.");

            RuleFor(x => x.AllocatedAmount)
                .GreaterThan(0)
                .WithMessage("Allocated amount must be greater than zero.");
        }
    }
}
