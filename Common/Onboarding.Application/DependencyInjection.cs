using MediatR;
using Onboarding.Application.Requests.Order;
using Onboarding.Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Onboarding.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateOrderHandler));
            services.AddMediatR(typeof(GetOrderByIdHandler));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(GetOrderByIdValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
