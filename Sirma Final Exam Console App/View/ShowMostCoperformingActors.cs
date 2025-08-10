using Sirma_Final_Exam_Console_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Final_Exam_Console_App.View
{
    internal class ShowMostCoperformingActors
    {
        public static void Show(Dictionary<KeyValuePair<int, int>, KeyValuePair<int, HashSet<int>>> mostPerformances, List<Actor> actors, List<Movie> movies)
        {

            foreach (var pair in mostPerformances)
            {
                var actor1 = actors.Find(a => a.Id == pair.Key.Key);
                var actor2 = actors.Find(a => a.Id == pair.Key.Value);
                var movieIds = pair.Value.Value;
                string movieTitlesYears = string.Join(", ", movies.Where(m => movieIds.Contains(m.Id)).Select(m => $"{m.Title}({m.ReleaseDate.Year})"));
                Console.WriteLine($"Actors: {actor1.FullName} and {actor2.FullName} have co-performed {pair.Value.Key} times in movies with Title(Year): {movieTitlesYears}");
            }
        }
    }
}
