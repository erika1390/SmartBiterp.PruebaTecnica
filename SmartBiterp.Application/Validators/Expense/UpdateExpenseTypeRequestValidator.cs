using FluentValidation;

using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Validators.Expense
{
    public class UpdateExpenseTypeRequestValidator : AbstractValidator<UpdateExpenseTypeRequest>
    {
        public UpdateExpenseTypeRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Invalid id.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Category)
                .NotEmpty();
        }
    }
}
