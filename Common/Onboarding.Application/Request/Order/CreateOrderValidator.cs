using FluentValidation;

namespace Onboarding.Application.Request.Order
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(o => o.Account).NotEmpty().WithMessage("Account number is required");

            RuleFor(o => o.Account)
                .Matches("^[0-9]+$")
                .WithMessage("Account number must be numbers only");

            RuleFor(o => o.InternalContractCode)
                .NotEmpty()
                .WithMessage("Internal contract code is required");
        }
    }
}
