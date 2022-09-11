using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Assignment.MovieData
{
    internal class Movies
    {
        public static void MovieData (string input)
        {
            string file = $"{Environment.CurrentDirectory}/data/movies.csv";

            List<UInt64> MovieIds = new List<UInt64>(); 
            List<string> MovieTitles = new List<string>();
            List<string> MovieGenres = new List<string>();

            try
            {
                StreamReader sr = new StreamReader(file);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    int idx = line.IndexOf('"');
                    if(idx == -1)
                    {
                        string[] movieDetails = line.Split(',');
                        MovieIds.Add(UInt64.Parse(movieDetails[0]));
                        MovieTitles.Add(movieDetails[1]);

                        MovieGenres.Add(movieDetails[2].Replace("|", ", "));


                    }
                    else
                    {
                        MovieIds.Add(UInt64.Parse(line.Substring(0, idx - 1)));

                        line = line.Substring(idx + 1);

                        idx = line.IndexOf('"');
                        MovieTitles.Add(line.Substring(0, idx));
                        line = line.Substring(idx + 2);
                        MovieGenres.Add(line.Replace("|", ", "));
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);    
            }
            Logger.Info("Movies in file {Count}", MovieIds.Count);




        }
    }
}
