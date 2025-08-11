using Sirma_Final_Exam_Console_App.Entities;
using Sirma_Final_Exam_Console_App.Model;
using System;
using System.Data.SqlClient;


namespace Sirma_Final_Exam_Console_App.Controller
{
    public static class CommandOptionController
    {
        public static void ExecuteCommand(string command, SqlConnection connection)
        {
            switch (command)
            {
                case "1":
                    RecordsManipulation.ListRecords("GetActors", connection);
                    break;
                case "2":
                    RecordsManipulation.ListRecords("GetMovies", connection);
                    break;
                case "3":
                    RecordsManipulation.ListRecords("GetRoles", connection);
                    break;
                case "4":
                    Console.WriteLine("Enter actor name:");
                    int ActorID = RecordsManipulation.GetLastREcordID("Actor", connection) + 1;
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
                    RecordsManipulation.InsertActor(newActor, insertActorSql, connection);
                    break;
                case "5":
                    Console.WriteLine("Enter movie title:");
                    int MovieID = RecordsManipulation.GetLastREcordID("Movie", connection) + 1;
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
                    RecordsManipulation.InsertMovie(newMovie, insertMovieSql, connection);
                    break;
                case "6":
                    Console.WriteLine("Enter role name:");
                    int RoleID = RecordsManipulation.GetLastREcordID("Role", connection) + 1;
                    Console.WriteLine("Enter actor id");
                    int ActorIDRole = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter movie id");
                    int MovieIDRole = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter character name:");
                    string characterName = Console.ReadLine();
                    Role newRole = new Role
                    {
                        Id = RoleID,
                        ActorId = ActorIDRole,
                        MovieId = MovieIDRole,
                        CharacterName = characterName
                    };
                    string insertRoleSql = QueryStings.InsertQueries["InsertRole"];
                    RecordsManipulation.InsertRole(newRole, insertRoleSql, connection);
                    break;
                case "7":
                    // UpdateActor logic here
                    break;
                case "8":
                    // UpdateMovie logic here
                    break;
                case "9":
                    // UpdateRole logic here
                    break;
                case "10":
                    // DeleteActor logic here
                    break;
                case "11":
                    // DeleteMovie logic here
                    break;
                case "12":
                    // DeleteRole logic here
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }
}
