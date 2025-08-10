using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Final_Exam_Console_App.Model
{
    internal static class QueryStings
    {
        public static Dictionary<String, String> ListQueries = new Dictionary<string, string>
        {
            { "GetActors", "SELECT * FROM tbl_Actors" },
            { "GetMovies", "SELECT * FROM tbl_Movies" },
            { "GetRoles", "SELECT * FROM tbl_Roles" },
            //{ "GetMostCoPerformances", "SELECT Actor1Id, Actor2Id, COUNT(*) AS CoPerformanceCount FROM Roles GROUP BY Actor1Id, Actor2Id HAVING COUNT(*) > 1" }
        };

        public static Dictionary<String, String> InsertQueries = new Dictionary<string, string>
        {
            { "InsertActor", "INSERT INTO Actors (ActorID,FullName, BirthDate) VALUES (@ActorID, @FullName, @BirthDate)" },
            { "InsertMovie", "INSERT INTO Movies (MovieID, Title, ReleaseDate) VALUES (@MovieID, @Title, @ReleaseDate)" },
            { "InsertRole", "INSERT INTO Roles (RoleID, ActorId, MovieId, ROLENAME) VALUES (@RoleID, @ActorId, @MovieId, @ROLENAME)" }
        };

        public static Dictionary<String, String> UpdateQueries = new Dictionary<string, string>
        {
            { "UpdateActor", "UPDATE Actors SET FullName = @FullName, BirthDate = @BirthDate WHERE ActorID = @ActorID" },
            { "UpdateMovie", "UPDATE Movies SET Title = @Title, ReleaseDate = @ReleaseDate WHERE MovieID = @MovieID" },
            { "UpdateRole", "UPDATE Roles SET ROLENAME = @ROLENAME WHERE RoleID = @RoleID" }
        };

        public static Dictionary<String, String> DeleteQueries = new Dictionary<string, string>
        {
            { "DeleteActor", "DELETE FROM Actors WHERE ActorID = @ActorID" },
            { "DeleteMovie", "DELETE FROM Movies WHERE MovieID = @MovieID" },
            { "DeleteRole", "DELETE FROM Roles WHERE RoleID = @RoleID" }
        };

    }
}
