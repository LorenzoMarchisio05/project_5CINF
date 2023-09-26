using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Wheater.Commons.DB
{
    public sealed class AdoNetController
    {
        private string _connectionString;

        public AdoNetController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static string GetConnectionStringFromDBName(string name)
        {
            var db = AppDomain.CurrentDomain.BaseDirectory + name;
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={db};Integrated Security=True;Connect Timeout=30";
        }

        private bool TryInitConnection(out SqlConnection connection)
        {
            try
            {
                connection = new SqlConnection
                {
                    ConnectionString = _connectionString,
                };

                connection.Open();

                return true;
            }
            catch (Exception)
            {
                connection = null;
                return false;
            }
        }


        public DataTable ExecuteQuery(SqlCommand command)
        {
            var connected = TryInitConnection(out var connection);

            if (!connected)
            {
                return default(DataTable);
            }

            using (connection)
            {
                command.Connection = connection;

                var dataTable = new DataTable();

                var adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            var connected = TryInitConnection(out var connection);

            if (!connected)
            {
                return -1;
            }

            using (connection)
            {
                command.Connection = connection;

                return command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(SqlCommand command)
        {
            var connected = TryInitConnection(out var connection);

            if (!connected)
            {
                return default(object);
            }

            using (connection)
            {
                command.Connection = connection;

                return command.ExecuteScalar();
            }
        }
    }
}