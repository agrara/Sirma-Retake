using Sirma_Final_Exam_Console_App.Controller;
using Sirma_Final_Exam_Console_App.Entities;
using Sirma_Final_Exam_Console_App.View;
using Sirma_Final_Exam_Console_App.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Final_Exam_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePathActors = "actors.csv";
            string filePathMovies = "movies.csv";
            string filePathRoles = "roles.csv";

            Console.WriteLine("Loading data from SCV files...");
            List<Actor> actors = SCVLoader.LoadActors(filePathActors);
            List<Movie> movies = SCVLoader.LoadMovies(filePathMovies);
            List<Role> roles = SCVLoader.LoadRoles(filePathRoles);
            Console.WriteLine("Data loaded successfully!");
            Console.WriteLine();

            Dictionary<KeyValuePair<int, int>, KeyValuePair<int, HashSet<int>>> mostPerformances = mostCoPerformaces.GetMostCoPerformances(roles);
            ShowMostCoperformingActors.Show(mostPerformances, actors, movies);

            db.dbConnect();
            RecordsManipulation.ListRecords("GetActors", db.connection);
            Console.WriteLine();
            string option = string.Empty;
            GetCommands.GetCRUDCommand(ref option);
            

            db.dbDisconnect();
        }
    }
}