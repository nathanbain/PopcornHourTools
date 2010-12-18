using System;
using System.Collections.Generic;

namespace PopcornHourTools.MovieCatalog
{
    class MovieDisplay : IDisplayMovies
    {
        public void DisplayMovies(IEnumerable<IMovie> movies)
        {
            var count = 1;
            foreach (var movie in movies)
            {
                Console.WriteLine(String.Format("{0}: {1}", count,  movie));
            }
        }

        public void DisplayMovie(IMovie movie)
        {
            Console.WriteLine(String.Format("Title: {0}", movie.Title()));
            Console.WriteLine(String.Format("Genre: {0}",movie.Genre()));
        }
    }
}