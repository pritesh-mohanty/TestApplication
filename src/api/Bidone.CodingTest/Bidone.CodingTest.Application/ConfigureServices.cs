using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Bidone.CodingTest.Application.Common.Behaviours;

namespace Bidone.CodingTest.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });

            return services;
        }
    }
}
