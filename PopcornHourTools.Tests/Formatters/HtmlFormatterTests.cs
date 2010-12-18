using System;
using System.IO;
using NUnit.Framework;
using System.Reflection;

namespace PopcornHourTools.Tests.Formatters
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        string[] movies;
        string expected = @"<html><head><title>Movie Listing</title></head><body><table border='1' id='movie_listing_results'><tr><th>Name</th></tr><tr><td>movie 1<//td><//tr><tr><td>movie 2<//td><//tr></table></body></html>";

        [SetUp] 
        public void SetUp()
        {
            movies = new string[] {"movie 1", "movie 2"};
        }

        [Ignore]
        [Test]
        public void FindFoldersMatching_ShouldFindFoldersContainingPartialMatch()
        {
            var results = PopcornHourTools.HtmlFormatter.Generate(movies);

            Assert.That(results.Equals(expected));
        }
    }
}
