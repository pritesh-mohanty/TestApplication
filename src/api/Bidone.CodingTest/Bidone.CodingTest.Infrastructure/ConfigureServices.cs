using Bidone.CodingTest.Application.Common.Interfaces;
using Bidone.CodingTest.Infrastructure.Files;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Bidone.CodingTest.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFileStorageService, FileStorageService>();

            return services;
        }
    }
}
