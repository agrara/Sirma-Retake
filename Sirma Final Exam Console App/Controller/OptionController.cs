using Sirma_Final_Exam_Console_App.Entities;
using Sirma_Final_Exam_Console_App.Model;
using System;
using System.Data.SqlClient;

namespace Sirma_Final_Exam_Console_App.Controller
{
    internal static class OptionController
    {
        public static void ExecuteOption(string option, SqlConnection connection)
        {
            switch (option)
            {
                case "1":
                    Console.WriteLine("Option 1");
                    Model.RecordsManipulation.ListRecords("GetActors", Model.db.connection);
                    break;
                case "2":
                    Model.RecordsManipulation.ListRecords("GetMovies", Model.db.connection);
                    break;
                case "3":
                    Model.RecordsManipulation.ListRecords("GetRoles", Model.db.connection);
                    break;
                case "4":
                    Console.WriteLine("Enter actor name:");

                    int ActorID = Model.RecordsManipulation.GetLastREcordID("Actor", connection) + 1;
                    string actorName = Console.ReadLine();
                    Console.WriteLine("Enter actor birthdate (year/month/date)");
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());
                    Actor newActor = new Actor
                    {
                        Id = ActorID,
                        FullName = actorName,
                        BirthDate = birthDate
                    };
                    string insertActorSql = QueryStings.InsertQueries["InsertActor"];
                    Model.RecordsManipulation.InsertActor(newActor, insertActorSql, connection);
                    break;
                case "5":
                    Console.WriteLine("Enter movie title:");
                    int MovieID = Model.RecordsManipulation.GetLastREcordID("Movie", connection) + 1;
                    string movieTitle = Console.ReadLine();
                    Console.WriteLine("Enter movie release date (year/month/date):");
                    DateTime releaseDate = DateTime.Parse(Console.ReadLine());
                    Movie newMovie = new Movie
                    {
                        Id = MovieID,
                        Title = movieTitle,
                        ReleaseDate = releaseDate
                    };
                    string insertMovieSql = QueryStings.InsertQueries["InsertMovie"];
                    Model.RecordsManipulation.InsertMovie(newMovie, insertMovieSql, connection);
                    break;
                case "6":
                    Console.WriteLine("Enter role name:");
                    int RoleID = Model.RecordsManipulation.GetLastREcordID("Role", connection) + 1;
                    string roleName = Console.ReadLine();
                    Console.WriteLine("Enter actor ID:");
                    int actorId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter movie ID:");
                    int movieId = int.Parse(Console.ReadLine());
                    Role newRole = new Role
                    {
                        Id = RoleID,
                        CharacterName = roleName,
                        ActorId = actorId,
                        MovieId = movieId
                    };
                    string insertRoleSql = QueryStings.InsertQueries["InsertRole"];
                    Model.RecordsManipulation.InsertRole(newRole, insertRoleSql, connection);
                    break;
                case "7":
                    Console.WriteLine("Enter actor ID to update:");
                    int updateActorId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new actor name:");
                    string updatedActorName = Console.ReadLine();
                    Console.WriteLine("Enter new actor birthdate (year/month/date):");
                    DateTime updatedBirthDate = DateTime.Parse(Console.ReadLine());
                    Actor updatedActor = new Actor
                    {
                        Id = updateActorId,
                        FullName = updatedActorName,
                        BirthDate = updatedBirthDate
                    };
                    string updateActorSql = QueryStings.UpdateQueries["UpdateActor"];
                    Model.RecordsManipulation.UpdateActor(updatedActor, updateActorSql, connection);
                    break;
                case "8":
                    Console.WriteLine("Enter movie ID to update:");
                    int updateMovieId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new movie title:");
                    string updatedMovieTitle = Console.ReadLine();
                    Console.WriteLine("Enter new movie release date (year/month/date):");
                    DateTime updatedReleaseDate = DateTime.Parse(Console.ReadLine());
                    Movie updatedMovie = new Movie
                    {
                        Id = updateMovieId,
                        Title = updatedMovieTitle,
                        ReleaseDate = updatedReleaseDate
                    };
                    string updateMovieSql = QueryStings.UpdateQueries["UpdateMovie"];
                    Model.RecordsManipulation.UpdateMovie(updatedMovie, updateMovieSql, connection);
                    break;
                case "9":
                    Console.WriteLine("Enter role ID to update:");
                    int updateRoleId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new role name:");
                    string updatedRoleName = Console.ReadLine();
                    Role updatedRole = new Role
                    {
                        Id = updateRoleId,
                        CharacterName = updatedRoleName
                    };
                    string updateRoleSql = QueryStings.UpdateQueries["UpdateRole"];
                    Model.RecordsManipulation.UpdateRole(updatedRole, updateRoleSql, connection);
                    break;
                case "10":
                    Console.WriteLine("Enter actor ID to delete:");
                    int deleteActorId = int.Parse(Console.ReadLine());
                    string deleteActorSql = QueryStings.DeleteQueries["DeleteActor"];
                    Model.RecordsManipulation.DeleteActor(deleteActorId, deleteActorSql, connection);
                    break;
                case "11":
                    Console.WriteLine("Enter movie ID to delete:");
                    int deleteMovieId = int.Parse(Console.ReadLine());
                    string deleteMovieSql = QueryStings.DeleteQueries["DeleteMovie"];
                    Model.RecordsManipulation.DeleteMovie(deleteMovieId, deleteMovieSql, connection);
                    break;
                case "12":
                    Console.WriteLine("Enter role ID to delete:");
                    int deleteRoleId = int.Parse(Console.ReadLine());
                    string deleteRoleSql = QueryStings.DeleteQueries["DeleteRole"];
                    Model.RecordsManipulation.DeleteRole(deleteRoleId, deleteRoleSql, connection);
                    break;
                case "13":
                    Console.WriteLine("Exiting the application.");
                    break;

                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }
        }
    }
}
