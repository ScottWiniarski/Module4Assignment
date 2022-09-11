using Module4Assignment.MovieData;
using System;

namespace Module4Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Info("Program started.");

            string file = $"{Environment.CurrentDirectory}/data/movies.csv";

            if (!file.Exists(file))
            {
                logger.Error("File does not exist: {File}", file);   
            }
            else
            {
                Console.WriteLine($"(1) Add Movie\n(2) Display All Movies\nEnter any other key to quit");

                string input = Console.ReadLine();
                logger.Info("User choice: {Input}", input);
                MovieData(input);


            }
        }
    }
}
