using FluentValidation;

using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Validators.Expense
{
    public class UpdateExpenseDetailRequestValidator : AbstractValidator<UpdateExpenseDetailRequest>
    {
        public UpdateExpenseDetailRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Detail Id must be greater than zero.");

            RuleFor(x => x.ExpenseTypeId)
                .GreaterThan(0).WithMessage("ExpenseTypeId must be greater than zero.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");
        }
    }
}