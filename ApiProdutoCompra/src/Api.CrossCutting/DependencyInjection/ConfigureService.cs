using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Products;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IError, Error>();
        }
    }
}
