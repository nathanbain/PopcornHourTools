using System.Collections.Generic;

namespace PopcornHourTools.MovieCatalog
{
    public interface IDisplayMovies
    {
        void DisplayMovies(IEnumerable<IMovie> movies);
        void DisplayMovie(IMovie movie);
    }
}