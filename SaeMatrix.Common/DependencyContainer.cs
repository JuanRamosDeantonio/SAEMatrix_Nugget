using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaeMatrix.Common.Managers.Implementations;
using SaeMatrix.Common.Managers.Interfaces;

namespace SAE.Matrix.Common
{
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