namespace TeamsRSSFeed.Domain.Interfaces.Configuration
{
    public interface IConfigurationReader
    {
        string RSSFeedDatabaseConnectionString { get; }
    }
}
