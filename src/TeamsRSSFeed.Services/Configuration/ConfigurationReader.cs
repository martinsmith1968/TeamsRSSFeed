using Microsoft.Extensions.Configuration;
using TeamsRSSFeed.Domain.Interfaces.Configuration;

namespace TeamsRSSFeed.Services.Configuration
{
    public class ConfigurationReader : IConfigurationReader
    {
        private readonly IConfiguration _configuration;

        public ConfigurationReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string RSSFeedDatabaseConnectionString => _configuration
            .GetConnectionString(Constants.Database.RSSFeedDatabaseConnectionStringName);
    }
}
