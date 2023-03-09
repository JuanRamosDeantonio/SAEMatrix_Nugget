using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SAE.Matrix.Common
{
    using Contracts.Managers;
    using Implementations.Managers;

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