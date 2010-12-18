using System;
using System.Collections.Generic;

namespace PopcornHourTools.MovieCatalog
{
    public class MovieCatalog : ICatalogMovies
    {
        private IDisplayMovies display;
        private List<IMovie> movies;

        public  MovieCatalog(IDisplayMovies display, List<IMovie> movies)
        {
            this.display = display;
            this.movies = movies;
        }

        public void FindAllMovies()
        {
            display.DisplayMovies(movies);
        }

        public void FindAllMoviesInGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void FindMovie(string movieName)
        {
            throw new NotImplementedException();
        }
    }
}