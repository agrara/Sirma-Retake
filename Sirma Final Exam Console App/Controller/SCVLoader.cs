using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Sirma_Final_Exam_Console_App
{
    internal class SCVLoader
    {
        public static List<Entities.Actor> LoadActors(string filePath)
        {
            var actors = new List<Entities.Actor>();
            var lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines.Skip(1))
            {
                string[] lineParts = line.Split(',');
                if (lineParts.Length != 3) continue;
                
                    actors.Add(new Entities.Actor
                    {
                        Id = int.Parse(lineParts[0].Trim()),
                        FullName = lineParts[1].Trim(),
                        BirthDate = DateTime.Parse(lineParts[2].Trim())
                    });
                
            }
            return actors;
        }

        public static List<Entities.Movie> LoadMovies(string filePath) {
            List<Entities.Movie> movies = new List<Entities.Movie>();
            var lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines.Skip(1))
            {
               string[] lineParts = line.Split(',');
                if (lineParts.Length != 3) continue;
                movies.Add(new Entities.Movie
                {
                    Id = int.Parse(lineParts[0].Trim()),
                    Title = lineParts[1].Trim(),
                    ReleaseDate = DateTime.ParseExact(lineParts[2].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture)
                });
            }

            return movies;

        }
        public static List<Entities.Role> LoadRoles(string filePath)
        {
            var roles = new List<Entities.Role>();
            var lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines.Skip(1))
            {
                string[] lineParts = line.Split(',');
                if (lineParts.Length != 4) continue;
                roles.Add(new Entities.Role
                {
                    Id = int.Parse(lineParts[0].Trim()),
                    ActorId = int.Parse(lineParts[1].Trim()),
                    MovieId = int.Parse(lineParts[2].Trim()),
                    CharacterName = string.IsNullOrWhiteSpace(lineParts[3]) || lineParts[3].Trim().ToUpper() == "NULL" ? null : lineParts[3].Trim()
                });
            }
            return roles;
        }
    }
}
