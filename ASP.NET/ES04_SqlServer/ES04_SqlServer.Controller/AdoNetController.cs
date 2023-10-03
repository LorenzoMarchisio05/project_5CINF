using System;
using System.Data;
using System.Data.SqlClient;

namespace ES04_SqlServer.Controller
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
			SqlConnection connection;
            var connected = TryInitConnection(out connection);

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
			SqlConnection connection;
            var connected = TryInitConnection(out connection);

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
			SqlConnection connection;
            var connected = TryInitConnection(out connection);

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