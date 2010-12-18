using System;

namespace PopcornHourTools.MovieCatalog
{
    public class Movie : IMovie
    {
        public Movie(string title)
        {
            this.title = title;
            genre = Genre().Undefined;
        }

        public override string ToString()
        {
            return Title();
        }

        private string title;
        public string Title()
        {
            return title;
        }

        private Genre genre;
        public Genre Genre()
        {
            return genre;
        }
    }
}