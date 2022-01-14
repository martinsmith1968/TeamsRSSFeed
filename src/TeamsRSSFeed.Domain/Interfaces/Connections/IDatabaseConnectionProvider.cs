using System.Data;

namespace TeamsRSSFeed.Domain.Interfaces.Connections
{
    public interface IDatabaseConnectionProvider
    {
        IDbConnection GetConnection(string connectionString);
    }
}
