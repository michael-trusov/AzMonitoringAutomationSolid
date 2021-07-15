using AZMA.Application.DataStorage;
using AZMA.Application.Interfaces;
using AZMA.Application.Models;
using AZMA.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AZMA.Application.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITestSession, TestSession>();
            serviceCollection.AddSingleton<ITestCasesDescriptions, TestScenarios>();
            
            serviceCollection.AddSingleton<IHistoryDataStorage<TestHistoryDataItem>, TestsHistoryDataStorage>();
            serviceCollection.AddSingleton<IHistoryDataStorage<TestSessionInfo>, TestSessionsHistoryDataStorage>();

            return serviceCollection;
        }
    }
}
