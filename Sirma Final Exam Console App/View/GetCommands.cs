using Sirma_Final_Exam_Console_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirma_Final_Exam_Console_App.View
{
    internal class GetCommands
    {
        public static List<string> Commands = new List<string>
        {
            "1. ListActors",
            "2. ListMovies",
            "3. ListRoles",
            "4. InsertActor",
            "5. InsertMovie",
            "6. InsertRole",
            "7. UpdateActor",
            "8. UpdateMovie",
            "9. UpdateRole",
            "10. DeleteActor",
            "11. DeleteMovie",
            "12. DeleteRole",
        };

        public static void GetCRUDCommand(ref string option)
        {
            foreach (var command in Commands)
            {
                Console.WriteLine(command);
                if (command == "3. ListRoles" || command == "6. InsertRole" || command == "9. UpdateRole")
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Choose what to do, select a number.");
            string input = Console.ReadLine();
            option = input;

        }
    }
}
