using System;
using System.Data;
using System.Data.SqlClient;

namespace Aplicación_SD_Web_Server.DB
{
    public class DatabaseManager : IDisposable
    {
        private readonly SqlConnection _connection;

        public DatabaseManager(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection Connection => _connection;

        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Dispose();
        }


    }
}