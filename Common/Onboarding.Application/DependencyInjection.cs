using MediatR;
using Onboarding.Application.Request.Order;
using Onboarding.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Onboarding.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateOrderHandler));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
