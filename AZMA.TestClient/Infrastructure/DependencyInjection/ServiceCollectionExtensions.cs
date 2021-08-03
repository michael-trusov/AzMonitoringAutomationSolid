using AZMA.TestClient.Emulators.MetricAlerts;
using AZMA.TestClient.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestClient.HttpClients;
using AZMA.Application.Infrastructure.Configuration;

namespace AZMA.TestClient.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTestClientServices(this IServiceCollection serviceCollection, IAppSettings appSettings)
        {
            serviceCollection.AddHttpClient<TestApiHttpClient>();

            serviceCollection.AddTransient<Muc1EmulationService>();
            serviceCollection.AddTransient<Muc2EmulationService>();
            serviceCollection.AddTransient<Muc3EmulationService>();
            serviceCollection.AddTransient<Muc4EmulationService>();
            serviceCollection.AddTransient<Muc5EmulationService>();
            serviceCollection.AddTransient<Muc6EmulationService>();
            serviceCollection.AddTransient<Muc7EmulationService>();            

            return serviceCollection;
        }
    }
}
