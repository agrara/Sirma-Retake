using Sirma_Final_Exam_Console_App.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sirma_Final_Exam_Console_App.Model
{
    internal static class RecordsManipulation
    {
        public static void InitialInsert(SqlConnection connection, List<Actor> actors, List<Movie> movies, List<Role> roles)
        {
            foreach (var actor in actors)
            {
                InsertActor(actor, QueryStings.InsertQueries["InsertActor"], connection);
            }
            foreach (var movie in movies)
            {
                InsertMovie(movie, QueryStings.InsertQueries["InsertMovie"], connection);
            }
            foreach (var role in roles)
            {
                InsertRole(role, QueryStings.InsertQueries["InsertRole"], connection);
            }
        }
        public static string GetRecordById(string command, int id, SqlConnection connection)
        {
            string query = QueryStings.GetRecordById[command];
            using (SqlCommand sqlCommand = new SqlCommand(query, connection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                object result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString();
                }
                return null;
            }
        }
        public static int GetLastREcordID(string Entity, SqlConnection connection)
        {
            string IDColumn;
            string tblName;
            switch (Entity.ToLower())
            {
                case "actor":
                    IDColumn = "ActorID";
                    tblName = "tbl_Actors";
                    break;
                case "movie":
                    IDColumn = "MovieID";
                    tblName = "tbl_Movies";
                    break;
                case "role":
                    IDColumn = "RoleID";
                    tblName = "tbl_Roles";
                    break;
                default:
                    throw new ArgumentException("Invalid table name");
            }
            string query = $"SELECT MAX({IDColumn}) FROM {tblName} ";
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
            }
        }

        public static void InsertRole(Role role, string sql, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@RoleID", role.Id);
                command.Parameters.AddWithValue("@ActorId", role.ActorId);
                command.Parameters.AddWithValue("@MovieId", role.MovieId);
                command.Parameters.AddWithValue("@ROLENAME", string.IsNullOrEmpty(role.CharacterName) ? (object)DBNull.Value : role.CharacterName);
                int rows = command.ExecuteNonQuery();
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
