using NUnit.Framework;
using PopcornHourTools.CollectionUtils;

namespace PopcornHourTools.Tests.CollectionUtils
{
    [TestFixture]
    public class MovieFolderFinderTests
    {
        private string startupPath;
        private string testDataLocation;
        private string[] locations;

        [SetUp]
        public void SetUp() 
        {
            startupPath = System.IO.Directory.GetCurrentDirectory();
            testDataLocation = @"CollectionUtils\Test Data\FolderUtils";
            locations = new[] { string.Format(@"{0}\..\..\{1}", startupPath, testDataLocation) };
        }

        [Test]
        public void FindFoldersMatching_ShouldFindFoldersContainingPartialMatch()
        {
            string expected = string.Format(@"{0}\..\..\{1}\dir with both", startupPath, testDataLocation);
            var results = ResultFinder.GetMatches(locations, "both");

            Assert.That(results.Contains(expected));
        }

        [Test]
        public void FindFoldersMatching_ShouldFindOnlyOneFoldersContainingExactMatch()
        {
            string expected = string.Format(@"{0}\..\..\{1}\dir with no jpg or nfo", startupPath, testDataLocation);
            var results = ResultFinder.GetMatches(locations, "dir with no jpg or nfo");

            Assert.That(results.Contains(expected));
        }

        [Test]
        public void FindFoldersMatching_ShouldFindMultipleFoldersContainingSamePartialMatch()
        {
            var results = ResultFinder.GetMatches(locations, "dir");

            Assert.That(results.Count == 5);
        }

        [Test]
        public void FindFoldersMatching_ShouldNotFindAnyResultsWhenNoMatch()
        {
            var results = ResultFinder.GetMatches(locations, "blah");

            Assert.That(results.Count == 0);
        }

        [Test]
        public void GetSearchDirectories_ShouldReturnListOfSpecifiedDirectories()
        {
            var results = PopcornHourTools.CollectionUtils.MovieFolderFinder.GetSearchDirectories();

            Assert.That(results.Count == 3);
        }

        [Test]
        public void GetFullListing_ShouldReturnListOfSpecifiedDirectories()
        {
            var expectedLocations = new string[] {"dir with both", "dir with no jpg", "dir with no jpg or nfo", "dir with no nfo", "empty dir"};
            var results = PopcornHourTools.CollectionUtils.MovieFolderFinder.GetFullListing(locations);

            Assert.That(results.Count == 5);
        }
    }
}