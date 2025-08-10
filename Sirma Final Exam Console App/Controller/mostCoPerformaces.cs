using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirma_Final_Exam_Console_App.Entities;

namespace Sirma_Final_Exam_Console_App.Controller
{
    internal static class mostCoPerformaces
    {
        // First KVP are the actors, second is the number of occurances and the movies they co-performed in
        public static Dictionary<KeyValuePair<int, int>, KeyValuePair<int, HashSet<int>>> GetMostCoPerformances(List<Role> roles) { 
            SortedDictionary<int, List<int>> actorCoPerformances = new SortedDictionary<int, List<int>>();
            foreach (var role in roles)
            {
                if (!actorCoPerformances.ContainsKey(role.MovieId))
                {
                    actorCoPerformances[role.MovieId] = new List<int>();
                }
                actorCoPerformances[role.MovieId].Add(role.ActorId);
            }
            //Workind with the co-performances 
            Dictionary< KeyValuePair<int, int>, KeyValuePair<int, HashSet<int>> > result = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, HashSet<int>>>();
            foreach (var movie in actorCoPerformances) { 
                for(int i = 0; i < movie.Value.Count - 1; i++)
                {
                    for (int j = i + 1; j < movie.Value.Count; j++)
                    {
                        int actor1 = movie.Value[i];
                        int actor2 = movie.Value[j];

                        KeyValuePair<int, int> actorsPair = new KeyValuePair<int, int>(Math.Min(actor1, actor2), Math.Max(actor1, actor2));
                        if (!result.ContainsKey(actorsPair))
                        {
                            result[actorsPair] = new KeyValuePair<int, HashSet<int>>(1, new HashSet<int> { movie.Key });
                        }
                        else
                        {
                            
                            var currentMovies = result[actorsPair].Value;
                            //We don't want to add the same movie again if duplicated
                            if (currentMovies.Add(movie.Key))
                                {
                                var currentCount = result[actorsPair].Key;
                                currentCount++;

                                result[actorsPair] = new KeyValuePair<int, HashSet<int>>(currentCount, currentMovies);
                            }
                        }
                    }
                }
            }

            int maxCoPerformances = result.Values.Max(x => x.Key);
            List<KeyValuePair<int, int>> keys = result.Where(x => x.Value.Key == maxCoPerformances)
                .Select(x => x.Key)
                .ToList();
            Dictionary<KeyValuePair<int, int>, KeyValuePair<int, HashSet<int>>> finalResult = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, HashSet<int>>>();
            foreach (var key in keys)
            {
                finalResult[key] = result[key];
            }
            return finalResult;
        }
    }
}
