using MySql.Data.MySqlClient;

namespace Abot_Kamay_Tracking_and_Queuing_System.Utilities
{
    internal static class DatabaseConnection
    {
        private static string connectionString = "server=127.0.0.1; user=root; database=tqsystemdb; password=root";

        // Method to get a new open connection
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open(); // Open the connection here
            return connection;
        }
    }
}
