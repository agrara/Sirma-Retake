using System;

namespace Sirma_Final_Exam_Console_App.Model
{
    internal static class ImportDataFromCSV
    {
        public static void GetDecision(ref String decision)
        {
            Console.WriteLine("Do you want to import data fof SCVs to database? (Y/N)");
            decision = Console.ReadLine().ToLower();
        }
    }
}
