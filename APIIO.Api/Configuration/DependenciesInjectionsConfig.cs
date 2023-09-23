using APIIO.Business.Interfaces.Repositories;
using APIIO.Business.Interfaces.Services;
using APIIO.Business.Services;
using APIIO.Data.Context;
using APIIO.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace APIIO.Api.Configuration
{
    public static class DependenciesInjectionsConfig
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbApiContext> ();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
