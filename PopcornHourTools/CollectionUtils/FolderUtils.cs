using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PopcornHourTools.CollectionUtils
{
    public class FolderUtils
    {
        public void FolderContentInfo()
        {
            Console.Clear();
            Console.WriteLine("Welcome to FolderContentInfo Version 0.1");
            Console.WriteLine("_______________________________________");
            Console.WriteLine("This utility will provide a list of folders which do not contain a nfo or jpg file.");
            Console.WriteLine("A useful list for organising your PopcornHour collection.");
            Console.WriteLine("");
            Console.WriteLine("Do you want to find (N)fo's (J)pg's or (B)oth?");
            String selection = Console.ReadLine();

            while (!String.Equals(selection, "N", StringComparison.InvariantCultureIgnoreCase) &&
                  !String.Equals(selection, "J", StringComparison.InvariantCultureIgnoreCase) &&
                  !String.Equals(selection, "B", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine(String.Format("{0} unrecognised. Do you want to find (N)fo's (J)pg's or (B)oth?", selection));
                selection = Console.ReadLine();
            }

            Console.WriteLine("");
            Console.WriteLine("Enter the path to the movie folders:");
            string moviesLocation = Console.ReadLine();

            switch (selection)
            {
                case "n":
                case "N":
                    {
                        GenerateNfoList(moviesLocation);
                        break;
                    }
                case "j":
                case "J":
                    {
                        GenerateJpgList(moviesLocation);
                        break;
                    }
                case "b":
                case "B":
                    {
                        GenerateNfoList(moviesLocation);
                        GenerateJpgList(moviesLocation);
                        break;
                    }
            }
        }

        private void GenerateJpgList(string moviesLocation)
        {
            Console.WriteLine("Locations with no .jpg:");
            foreach (var file in GetFoldersWithNoJpgFile(moviesLocation))
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void GenerateNfoList(string moviesLocation)
        {
            Console.WriteLine("Locations with no .nfo:");
            foreach (var file in GetFoldersWithNoNfoFile(moviesLocation))
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public List<string> GetFoldersWithNoJpgFile(string moviesLocation)
        {
            return GetListOfDirectoriesWithoutaFileWithPrefix(moviesLocation, "jpg");
        }

        public List<string> GetFoldersWithNoNfoFile(string moviesLocation)
        {
            return GetListOfDirectoriesWithoutaFileWithPrefix(moviesLocation, "nfo");
        }

        public List<string> GetListOfDirectoriesWithoutaFileWithPrefix(string moviesLocation, string prefix)
        {
            var matchingDirectories = new List<string>();

            foreach (string d in Directory.GetDirectories(moviesLocation))
            {
                Console.WriteLine(String.Format("Checking {0}", d));

                if (!HasPrefix(d, prefix))
                    matchingDirectories.Add(d);
            }
            return matchingDirectories;
        }

        public bool HasPrefix(string directory, string prefix)
        {
            foreach (string f in Directory.GetFiles(directory))
            {
                if (f.EndsWith(prefix.ToLower(), true, CultureInfo.CurrentCulture) || f.EndsWith(prefix.ToUpper(), true, CultureInfo.CurrentCulture))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
