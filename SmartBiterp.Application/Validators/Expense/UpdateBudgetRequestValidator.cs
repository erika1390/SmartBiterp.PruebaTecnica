using FluentValidation;

using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Validators.Expense
{
    public class UpdateBudgetRequestValidator : AbstractValidator<UpdateBudgetRequest>
    {
        public UpdateBudgetRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Budget ID must be greater than zero.");

            RuleFor(x => x.AllocatedAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Allocated amount cannot be negative.");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid budget status.");
        }
    }
}
