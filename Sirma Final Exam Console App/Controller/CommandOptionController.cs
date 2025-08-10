using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirma_Final_Exam_Console_App.Model;
using Sirma_Final_Exam_Console_App.Entities;


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
                    // InsertMovie logic here
                    break;
                case "6":
                    // InsertRole logic here
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
