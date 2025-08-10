//First add Microsoft SQL client using console: "dotnet add package Microsoft.Data.SqlClient"
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Final_Exam_Console_App.Model
{
    internal static class db
    {
        private static string serverName = "localhost\\MSSQLSERVERDEV";  //Change with the name with your SQL Server instance
        private static string databaseName = "SIRMA_EXAM"; // Change to your database name
        private static string connectionString = $"Server={serverName};Database={databaseName};Trusted_Connection=True;";
        static SqlConnection connection = new SqlConnection(connectionString);
        public static void dbConnect()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection to the database established successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }
        }

        public static void dbDisconnect()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Connection to the database closed successfully.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error disconnecting from the database: {ex.Message}");
            }
        }

    }
}
