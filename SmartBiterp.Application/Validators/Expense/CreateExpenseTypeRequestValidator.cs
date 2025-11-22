using FluentValidation;

using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Validators.Expense
{
    public class CreateExpenseTypeRequestValidator : AbstractValidator<CreateExpenseTypeRequest>
    {
        public CreateExpenseTypeRequestValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(100);

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.");
        }
    }
}
