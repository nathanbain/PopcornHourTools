using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PopcornHourTools.CollectionUtils
{
    public class MovieFolderFinder
    {
        List<String> searchLocations;

        public MovieFolderFinder()
        {
            searchLocations = new List<string>();
        }

        public void FindFolders()
        {
            Console.Clear();
            Console.WriteLine("Welcome to MovieFolderFinder Version 0.1");
            Console.WriteLine("_______________________________________");
            Console.WriteLine("This utility will provide a list of folders which contain a given movie name.");
            Console.WriteLine("");
            Console.WriteLine("The movie locations to be searched are:-");

            searchLocations = GetSearchDirectories();

            foreach(var directory in searchLocations)
            {
                Console.WriteLine(String.Format(">> {0}", directory));
            }

            Console.WriteLine("");
            Console.WriteLine("Are these locations OK? Y or N.");
            String selection = Console.ReadLine();

            while (!String.Equals(selection, "Y", StringComparison.InvariantCultureIgnoreCase) &&
                  !String.Equals(selection, "N", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Are these locations OK? Y or N.");
                selection = Console.ReadLine();
            }

            if(String.Equals(selection, "N", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Enter a location to search:-");
                searchLocations.Clear();
                searchLocations.Add(Console.ReadLine());
            }

            Search();

            bool done = false;

            while (!done)
            {

                Console.WriteLine("Search again?");
                String again = Console.ReadLine();

                if (!String.Equals(again, "Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    done = true;
                }
                Search();
            }
            
        }

        public void Search()
        {
            Console.Clear();
            Console.WriteLine("What movie name are we searching for?");
            String textToMatch = Console.ReadLine();

            while (String.IsNullOrEmpty(textToMatch))
            {
                Console.WriteLine("What movie name are we searching for?");
                textToMatch = Console.ReadLine();
            }

            Console.WriteLine("");

            var matches = ResultFinder.GetMatches(searchLocations, textToMatch);

            if (matches.Count == 0)
            {
                Console.WriteLine("No matches found.");
            }
            else
            {
                Console.WriteLine(String.Format("Found {0} movies", matches.Count));
                foreach (var match in matches)
                {
                    Console.WriteLine(">> " + match);
                }
            }
            Console.ReadLine();
        }

        public static List<string> GetSearchDirectories()
        {
            Assembly assembly;
            StreamReader textStreamReader;
            var directories = new List<string>();

            try
            {
                assembly = Assembly.GetExecutingAssembly();
                textStreamReader = new StreamReader(assembly.GetManifestResourceStream("PopcornHourTools.CollectionsConfig.txt"));

                while(textStreamReader.Peek() != -1)
                {
                    directories.Add(textStreamReader.ReadLine());
                }
            }
            catch
            {
            }

            return directories;
        }

        public static IList<string> GetFullListing(IList<string> locations)
        {
            return CleanupResults(ResultFinder.GetMatches(locations, "*"));
        }

        public void PrintFullMovieList()
        {
            Console.Clear();
            Console.WriteLine("Printing full movie list");
            Console.WriteLine("_______________________________________");
            searchLocations = GetSearchDirectories();

            var results = GetFullListing(searchLocations);

            foreach (string r in results)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }

        public void DumpFullMovieList()
        {
            Console.WriteLine("Dumping full movie list");
            Console.WriteLine("_______________________________________");

            searchLocations = GetSearchDirectories();
            var results = GetFullListing(searchLocations);

            TextWriter tw = new StreamWriter("movie_list.txt");
            foreach(string r in results)
                tw.WriteLine(r);
            tw.Close();

            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        public static List<string> ReadFullMovieListFromTextFile(string movieFileLocation)
        {
            using (TextReader tr = new StreamReader(movieFileLocation))
            {
                var movieList = new List<string>();
                string input;
                while ((input = tr.ReadLine()) != null)
                {
                    movieList.Add(input);
                }
                return movieList ;
            }
        }

        public void DumpFullMovieListAsHtml()
        {
            Console.WriteLine("Dumping full movie list");
            Console.WriteLine("_______________________________________");

            searchLocations = GetSearchDirectories();
            var results = HtmlFormatter.Generate(GetFullListing(searchLocations));

            TextWriter tw = new StreamWriter("movie_list.html");
            tw.WriteLine(results);
            tw.Close();

            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        public static IList<string> CleanupResults(IList<string> results)
        {
            var cleanedResults = new List<string>();
            foreach(string r in results)
            {
                cleanedResults.Add(CleanupResult(r));
            }
            cleanedResults.Sort();
            return cleanedResults;
        }

        public static string CleanupResult(string result)
        {
            var x = result.Substring(result.LastIndexOf(@"\") + 1);
            return x;
        }
    }
}
