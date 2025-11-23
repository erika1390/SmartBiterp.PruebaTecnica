using FluentValidation;

using SmartBiterp.Application.DTOs.Expense;

namespace SmartBiterp.Application.Validators.Expense
{
    public class UpdateExpenseHeaderRequestValidator : AbstractValidator<UpdateExpenseHeaderRequest>
    {
        public UpdateExpenseHeaderRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than zero.");

            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage("Date is required.");

            RuleFor(x => x.MoneyFundId)
                .GreaterThan(0)
                .WithMessage("MoneyFundId must be greater than zero.");

            RuleFor(x => x.StoreName)
                .NotEmpty().WithMessage("StoreName is required.")
                .MaximumLength(150).WithMessage("StoreName max length is 150 characters.");

            RuleFor(x => x.Observations)
                .MaximumLength(500).WithMessage("Observations max length is 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Observations));

            RuleFor(x => x.DocumentType)
                .IsInEnum()
                .WithMessage("Invalid DocumentType value.");

            RuleFor(x => x.Details)
                .NotEmpty()
                .WithMessage("At least one detail is required.");

            RuleForEach(x => x.Details)
                .SetValidator(new UpdateExpenseDetailRequestValidator());
        }
    }
}