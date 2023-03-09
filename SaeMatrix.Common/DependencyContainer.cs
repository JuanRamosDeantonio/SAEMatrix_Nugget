using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SAE.Matrix.Common
{
    using Managers.Implementations;
    using Managers.Interfaces;

    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            //Asset repositories
            services.AddScoped<IEmailManager, EmailManager>();

            return services;
        }
    }
}