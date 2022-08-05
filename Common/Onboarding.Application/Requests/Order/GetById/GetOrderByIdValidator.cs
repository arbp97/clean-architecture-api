using FluentValidation;

namespace Onboarding.Application.Requests.Orders
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdRequest>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(o => o.Id).NotEqual(Guid.Empty).WithMessage("Id is required");
        }
    }
}
