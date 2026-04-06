using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MKVS_Information_System.Database
{
    internal class DatabaseConnection
    {
        private MySqlConnection connection;

      
        private string connectionString = "server=localhost;user id=root;password=;database=mkvs_information_system;";

        public MySqlConnection GetConnection()
        {
            if (connection == null)
                connection = new MySqlConnection(connectionString);

            return connection;
        }

        public bool OpenConnection()
        {
            try
            {
                GetConnection().Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database connection failed!\n\n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing database connection:\n" + ex.Message);
            }
        }
    }
}
