using System;
using System.Data;
using System.Data.SqlClient;


namespace BancaDelTempo.Controller
{
    public sealed class AdoNetController
    {
        private readonly string _connectionString;
		
		public static string GetConnectionStringFromDBName(string name)
        {
            var db = AppDomain.CurrentDomain.BaseDirectory + name;
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + db + @";Integrated Security=True;Connect Timeout=30";
        }

        public AdoNetController(string connectionString)
        {
            _connectionString = connectionString;
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
                return default;
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
                return null;
            }

            using (connection)
            {
                command.Connection = connection;

                return command.ExecuteScalar();
            }
        }
    }
}