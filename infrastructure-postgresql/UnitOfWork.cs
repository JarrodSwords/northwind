using System;
using Npgsql;

namespace Northwind.Infrastructure.PostgreSql
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(string connectionString)
        {
            Connection = new NpgsqlConnection(connectionString);
            Connection.Open();
        }

        public NpgsqlConnection Connection { get; }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}