using FluentValidation;

namespace Onboarding.Application.Requests.Order
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdRequest>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(o => o.Id).NotEqual(Guid.Empty).WithMessage("Id is required");
        }
    }
}
