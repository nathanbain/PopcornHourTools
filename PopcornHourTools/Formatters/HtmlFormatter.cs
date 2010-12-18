using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornHourTools
{
    public static class HtmlFormatter
    {
        public static string Generate(IList<string> movies)
        {
            string moviesAsRows = "";
            string html = "";

            foreach (string m in movies)
            {
                moviesAsRows += string.Format(@"<tr><td>{0}<//td><td align=center>Thriller<//td><td align=center><img src='.\images\unknown_flag_icon.png' alt='Unknown'/><//td><td align=center><img src='.\images\tick_icon.png' alt='Y'/><//td><td align=center><img src='.\images\xIcon.png' alt='N'/><//td><//tr>", m);
            }
            html += @"<html>";
            html += @"<head><title>Movie Listing</title></head>";
            html += @"<body>";
            html += @"<table border='0' id='movie_listing_results'>";
            html += @"<tr><th>Name</th><th>Genre</th><th>Country</th><th>Watched</th><th>Favourite</th></tr>";
            html += moviesAsRows;
            html += @"</table>";
            html += @"</body>";
            html += @"</html>";

            return html;
        }
    }
}
