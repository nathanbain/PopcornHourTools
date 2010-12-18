using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PopcornHourTools.CollectionUtils
{
    public class ResultFinder
    {
        private const string wildcard = "*";

        public static IList<string> GetMatches(IList<string> locations, string match)
        {
            var matchingDirectories = new List<string>();

            foreach (var location in locations)
            {
                if(string.Equals(match, wildcard, StringComparison.InvariantCultureIgnoreCase))
                    matchingDirectories.AddRange(Directory.GetDirectories(location));

                matchingDirectories.AddRange(Directory.GetDirectories(location).Where(d => d.ToLower().Contains(match.ToLower())));
            }
            return matchingDirectories;
        }

        public static IList<string> GetAll(IList<string> locations)
        {
            var matchingDirectories = new List<string>();

            foreach (var location in locations)
            {
                matchingDirectories.AddRange(Directory.GetDirectories(location));
            }
            return matchingDirectories;
        }
    }
}