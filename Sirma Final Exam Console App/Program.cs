using Sirma_Final_Exam_Console_App.Controller;
using Sirma_Final_Exam_Console_App.Entities;
using Sirma_Final_Exam_Console_App.Model;
using Sirma_Final_Exam_Console_App.View;
using System;
using System.Collections.Generic;

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

            string importData = string.Empty;
            ImportDataFromCSV.GetDecision(ref importData);
            switch (importData)
            {
                case "y":
                    Model.RecordsManipulation.InitialInsert(db.connection, actors, movies, roles);
                    break;

            }

            //Model.RecordsManipulation.ListRecords("GetActors", Model.db.connection);

            Console.WriteLine();
            string option = string.Empty;

            while (option != "13")
            {
                GetCommands.GetCRUDCommand(ref option);
                OptionController.ExecuteOption(option, db.connection);
            }
            OptionController.ExecuteOption(option, db.connection);


            db.dbDisconnect();
        }
    }
}