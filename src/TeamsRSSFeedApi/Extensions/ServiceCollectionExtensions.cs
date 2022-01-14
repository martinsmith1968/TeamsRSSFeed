using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamsRSSFeed.Domain.Interfaces.Configuration;
using TeamsRSSFeed.Domain.Interfaces.Connections;
using TeamsRSSFeed.Domain.Interfaces.Repository;
using TeamsRSSFeed.Services.Configuration;
using TeamsRSSFeed.Services.Connections;
using TeamsRSSFeed.Services.Repository;

namespace TeamsRSSFeedApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddSingleton(configuration)
                .AddScoped<IConfigurationReader, ConfigurationReader>()
                .AddScoped<IDatabaseConnectionProvider, DatabaseConnectionProvider>()
                .AddScoped<IFeedRepository, FeedRepository>()
                .AddScoped<IFeedItemRepository, FeedItemRepository>()
                ;

            return serviceCollection;
        }
    }
}
