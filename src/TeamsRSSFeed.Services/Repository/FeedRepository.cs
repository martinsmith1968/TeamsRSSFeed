using System;
using System.Data;
using System.Linq;
using Dapper;
using TeamsRSSFeed.Domain.Interfaces.Configuration;
using TeamsRSSFeed.Domain.Interfaces.Connections;
using TeamsRSSFeed.Domain.Interfaces.Repository;
using TeamsRSSFeed.Domain.Models;

namespace TeamsRSSFeed.Services.Repository
{
    public class FeedRepository : IFeedRepository
    {
        private readonly string _connectionString;
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;

        public FeedRepository(
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

        public Feed Get(Guid id)
        {
            using var connection = GetConnection();

            var sql = "SELECT * FROM [Feed] WHERE [Id] = @id";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Guid, ParameterDirection.Input);

            var result = connection.Query<Feed>(sql, parameters)
                .FirstOrDefault();

            return result;
        }

        public Feed GetByTitle(string title)
        {
            using var connection = GetConnection();

            var sql = "SELECT * FROM [Feed] WHERE [Title] = @title";

            var parameters = new DynamicParameters();
            parameters.Add("@title", title, DbType.String, ParameterDirection.Input);

            var result = connection.Query<Feed>(sql, parameters)
                .FirstOrDefault();

            return result;
        }

        public Feed Create(string title, string description)
        {
            using var connection = GetConnection();

            var sql = "INSERT [Feed] ([Title], [Description]) VALUES (@title, @description)";

            var parameters = new DynamicParameters();
            parameters.Add("@title", title, DbType.String, ParameterDirection.Input);
            parameters.Add("@description", description, DbType.String, ParameterDirection.Input);

            connection.ExecuteScalar(sql, parameters);

            var result = GetByTitle(title);

            return result;
        }
    }
}
