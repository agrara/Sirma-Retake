using System;
using System.Collections.Generic;

namespace Sirma_Final_Exam_Console_App.Model
{
    internal static class QueryStings
    {
        public static Dictionary<String, String> GetRecordById = new Dictionary<string, string> {
            {"GetActorById", "SELECT * FROM tbl_Actors WHERE ActorID = @Id" },
            { "GetMovieById", "SELECT * FROM tbl_Movies WHERE MovieID = @Id" },
            { "GetRoleById", "SELECT * FROM tbl_Roles WHERE RoleID = @Id" }
        };

        public static Dictionary<String, String> ListQueries = new Dictionary<string, string>
        {
            { "GetActors", "SELECT * FROM tbl_Actors" },
            { "GetMovies", "SELECT * FROM tbl_Movies" },
            { "GetRoles", "SELECT tbl_Roles.RoleId, tbl_Roles.ROLENAME, tbl_Actors.ActorID, tbl_Actors.FullName, tbl_Movies.MovieID, tbl_Movies.Title  FROM tbl_Roles INNER JOIN tbl_Actors ON tbl_Actors.ActorID = tbl_Roles.ActorID INNER JOIN tbl_Movies ON tbl_Movies.MovieID = tbl_Roles.MovieID" },
            //{ "GetMostCoPerformances", "SELECT Actor1Id, Actor2Id, COUNT(*) AS CoPerformanceCount FROM Roles GROUP BY Actor1Id, Actor2Id HAVING COUNT(*) > 1" }
        };

        public static Dictionary<String, String> InsertQueries = new Dictionary<string, string>
        {
            { "InsertActor", "INSERT INTO tbl_Actors (ActorID,FullName, BirthDate) VALUES (@ActorID, @FullName, @BirthDate)" },
            { "InsertMovie", "INSERT INTO tbl_Movies (MovieID, Title, ReleaseDate) VALUES (@MovieID, @Title, @ReleaseDate)" },
            { "InsertRole", "INSERT INTO tbl_Roles (RoleID, ActorId, MovieId, ROLENAME) VALUES (@RoleID, @ActorId, @MovieId, @ROLENAME)" }
        };

        public static Dictionary<String, String> UpdateQueries = new Dictionary<string, string>
        {
            { "UpdateActor", "UPDATE tbl_Actors SET FullName = @FullName, BirthDate = @BirthDate WHERE ActorID = @ActorID" },
            { "UpdateMovie", "UPDATE tbl_Movies SET Title = @Title, ReleaseDate = @ReleaseDate WHERE MovieID = @MovieID" },
            { "UpdateRole", "UPDATE tbl_Roles SET ROLENAME = @ROLENAME WHERE RoleID = @RoleID" }
        };

        public static Dictionary<String, String> DeleteQueries = new Dictionary<string, string>
        {
            { "DeleteActor", "DELETE FROM tbl_Actors WHERE ActorID = @ActorID" },
            { "DeleteMovie", "DELETE FROM tbl_Movies WHERE MovieID = @MovieID" },
            { "DeleteRole", "DELETE FROM tbl_Roles WHERE RoleID = @RoleID" }
        };

    }
}
