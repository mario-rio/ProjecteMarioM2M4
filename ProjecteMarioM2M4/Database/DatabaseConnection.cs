using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteMarioM2M4.Database
{
    public class DatabaseConnection
    {
        public MySqlConnection Connection { get; private set; }
        private string connectionString;

        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool OpenConnection()
        {
            try
            {
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening database connection: " + ex.Message);
                return false;
            }
        }


        public bool CloseConnection()
        {
            try
            {
                if (Connection != null && Connection.State != System.Data.ConnectionState.Closed)
                {
                    Connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing database connection: " + ex.Message);
                return false;
            }
        }

        public bool ExecuteQuery(string query)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
                return false;
            }
        }

        public object ExecuteScalarQuery(string query)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, Connection);
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing scalar query: " + ex.Message);
                return null;
            }
        }
    }
}