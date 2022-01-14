using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TeamsRSSFeed.Domain.Interfaces.Configuration;
using TeamsRSSFeed.Domain.Interfaces.Connections;
using TeamsRSSFeed.Domain.Interfaces.Repository;
using TeamsRSSFeed.Domain.Models;

namespace TeamsRSSFeed.Services.Repository
{
    public class FeedItemRepository : IFeedItemRepository
    {
        private readonly string _connectionString;
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;

        public FeedItemRepository(
            IConfigurationReader configurationReader,
            IDatabaseConnectionProvider databaseConnectionProvider
        )
        {
            _connectionString = configurationReader.RSSFeedDatabaseConnectionString;
            _databaseConnectionProvider = databaseConnectionProvider;
        }

        private IDbConnection GetConnection()
        {
            return _databaseConnectionProvider.GetConnection(_connectionString);
        }

        public FeedItem Get(Guid id)
        {
            using var connection = GetConnection();

            var sql = "SELECT * FROM [FeedItem] WHERE [Id] = @id";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Guid, ParameterDirection.Input);

            var result = connection.Query<FeedItem>(sql, parameters)
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<FeedItem> GetByFeed(Guid feedId)
        {
            using var connection = GetConnection();

            var sql = "SELECT * FROM [FeedItem] WHERE [FeedId] = @feedId ORDER BY [CreatedDate] DESC";

            var parameters = new DynamicParameters();
            parameters.Add("@feedId", feedId, DbType.Guid, ParameterDirection.Input);

            var result = connection.Query<FeedItem>(sql, parameters);

            return result;
        }

        public FeedItem Create(Guid feedId, string text)
        {
            using var connection = GetConnection();

            var id = Guid.NewGuid();    // TODO: Convert to SP and return Id from there
            var sql = "INSERT [FeedItem] ([Id], [FeedId], [Text]) VALUES (@id, @feedId, @text)";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("@feedId", feedId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("@text", text, DbType.String, ParameterDirection.Input);

            connection.ExecuteScalar(sql, parameters);

            var result = Get(id);

            return result;
        }
    }
}
