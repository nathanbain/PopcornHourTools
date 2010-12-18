using System;
using PopcornHourTools.CollectionUtils;

namespace PopcornHourTools
{
    class Program
    {
        private static bool quit;
        private static MovieFolderFinder mff;
        private static FolderUtils utils;

        static void Main()
        {
            quit = false;
            mff = new MovieFolderFinder();
            utils = new FolderUtils();
            while (!quit)
            {
                PrintHeader();
                PrintMenuOptions();
                ProcessSelection(Console.ReadLine());
            }

        }

        private static void ProcessSelection(string selection)
        {
            switch (selection)
            {
                case "1":
                    utils.FolderContentInfo();
                    break;
                case "2":
                    mff.FindFolders();
                    break;
                case "3":
                    mff.DumpFullMovieList();
                    break;
                case "4":
                    mff.DumpFullMovieListAsHtml();
                    break;
                case "0":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Unknown selection.");
                    break;
            }
        }

        private static void PrintMenuOptions()
        {
            Console.WriteLine("1: Folder Utilities - search for missing nfo/jpg files in your popcornhour library");
            Console.WriteLine("2: Movie Finder - check if a movie folder exists in your popcornhour library");
            Console.WriteLine("3: Full Movie List - get full movie listings as a text file");
            Console.WriteLine("4: Full HTML Movie List - get full movie listings as an html file");
            Console.WriteLine("0: Quit");
            Console.WriteLine("");
            Console.Write(">> ");
        }

        private static void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("Welcome to PopcornHourTools Version 0.1");
            Console.WriteLine("_______________________________________");
        }
    }
}
