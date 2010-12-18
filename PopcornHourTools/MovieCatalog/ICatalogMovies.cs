using System.Collections.Generic;

namespace PopcornHourTools.MovieCatalog
{
    public interface ICatalogMovies
    {
        void FindAllMovies();
        void FindAllMoviesInGenre(Genre genre);
        void FindMovie(string movieName);
    }
}