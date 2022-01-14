using System.Data;
using Microsoft.Data.SqlClient;
using TeamsRSSFeed.Domain.Interfaces.Connections;

namespace TeamsRSSFeed.Services.Connections
{
    public class DatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
