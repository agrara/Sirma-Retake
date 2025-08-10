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

            List<Actor> actors = SCVLoader.LoadActors(filePathActors);
            List<Movie> movies = SCVLoader.LoadMovies(filePathMovies);
            List<Role> roles = SCVLoader.LoadRoles(filePathRoles);

            Dictionary<KeyValuePair<int, int>, KeyValuePair<int, HashSet<int>>> mostPerformances = mostCoPerformaces.GetMostCoPerformances(roles);
            ShowMostCoperformingActors.Show(mostPerformances, actors, movies);

            db.dbConnect();


            db.dbDisconnect();
        }
    }
}