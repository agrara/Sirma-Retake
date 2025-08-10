using Sirma_Final_Exam_Console_App.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Final_Exam_Console_App.Model
{
    internal static class RecordsManipulation
    {
        public static int GetLastREcordID(string Entity, SqlConnection connection)
        {
            string IDColumn;
            switch (Entity.ToLower())
            {
                case "actor":
                    IDColumn = "ActorID";
                    break;
                case "movie":
                    IDColumn = "MovieID";
                    break;
                case "role":
                    IDColumn = "RoleID";
                    break;
                default:
                    throw new ArgumentException("Invalid table name");
            }
            string query = $"SELECT MAX({IDColumn}) FROM {tblName}";
            using (SqlCommand sqlCommand = new SqlCommand(query, connection))
            {
                object result = sqlCommand.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int lastId))
                {
                    return lastId;
                }
                return 0; // Return 0 if no records found or parsing fails
            }
        }
        public static void ListRecords(string command, SqlConnection connection)
        {
            string query = QueryStings.ListQueries[command];
            using (SqlCommand sqlCommand = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i)}: {reader[i]} ");
                                if (i % 20 == 0)
                                {
                                    Console.WriteLine("Press any kaey to continue...");
                                    Console.ReadKey();  
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records found.");
                    }
                }
            }
        }

        //INSERTION
        public static void InsertActor(Actor actor, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@ActorID", actor.Id);
                command.Parameters.AddWithValue("@FullName", actor.FullName);
                command.Parameters.AddWithValue("@BirthDate", actor.BirthDate);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) inserted.");
            }
        }
        public static void InsertMovie(Movie movie, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@MovieID", movie.Id);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) inserted.");
            }
        }

        public static void InsertRole(Role role, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@RoleID", role.Id);
                command.Parameters.AddWithValue("@ActorId", role.ActorId);
                command.Parameters.AddWithValue("@MovieId", role.MovieId);
                command.Parameters.AddWithValue("@ROLENAME", role.CharacterName);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) inserted.");
            }
        }
        //UPDATION
        public static void UpdateActor(Actor actor, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@ActorID", actor.Id);
                command.Parameters.AddWithValue("@FullName", actor.FullName);
                command.Parameters.AddWithValue("@BirthDate", actor.BirthDate);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) updated.");
            }
        }
        public static void UpdateMovie(Movie movie, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@MovieID", movie.Id);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) updated.");
            }
        }
        public static void UpdateRole(Role role, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@RoleID", role.Id);
                command.Parameters.AddWithValue("@ROLENAME", role.CharacterName);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) updated.");
            }
        }
        //DELETION
        public static void DeleteActor(int actorId, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@ActorID", actorId);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) deleted.");
            }
        }
        public static void DeleteMovie(int movieId, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@MovieID", movieId);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) deleted.");
            }
        }
        public static void DeleteRole(int roleId, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@RoleID", roleId);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) deleted.");
            }
        }
    }
}
