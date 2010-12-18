using System;
using NUnit.Framework;

namespace PopcornHourTools.Tests.CollectionUtils
{
    [TestFixture]
    public class FolderUtilsTests
    {
        private string startupPath;
        private string testDataLocation;
        private PopcornHourTools.CollectionUtils.FolderUtils utils;

        [SetUp]
        public void Setup()
        {
            startupPath = System.IO.Directory.GetCurrentDirectory();
            testDataLocation = @"CollectionUtils\Test Data\FolderUtils";
            utils = new PopcornHourTools.CollectionUtils.FolderUtils();
        }

        [Test]
        public void GetFoldersWithNoJpegFile_ShouldReturnCorrectFolders()
        {
            var locations = utils.GetFoldersWithNoJpgFile(String.Format(@"{0}\..\..\{1}", startupPath, testDataLocation));
            Assert.That(locations.Contains(String.Format(@"G:\Projects\PopcornHourTools\PopcornHourTools.Tests\bin\Debug\..\..\{0}\dir with no jpg", testDataLocation)));
            Assert.That(locations.Contains(String.Format(@"G:\Projects\PopcornHourTools\PopcornHourTools.Tests\bin\Debug\..\..\{0}\dir with no jpg or nfo", testDataLocation)));
            Assert.That(locations.Contains(String.Format(@"G:\Projects\PopcornHourTools\PopcornHourTools.Tests\bin\Debug\..\..\{0}\empty dir", testDataLocation)));
        }

        [Test]
        public void GetFoldersWithNoNfoFile_ShouldReturnCorrectFolders()
        {
            var locations = utils.GetFoldersWithNoNfoFile(String.Format(@"{0}\..\..\{1}", startupPath, testDataLocation));
            Assert.That(locations.Contains(String.Format(@"G:\Projects\PopcornHourTools\PopcornHourTools.Tests\bin\Debug\..\..\{0}\dir with no nfo", testDataLocation)));
            Assert.That(locations.Contains(String.Format(@"G:\Projects\PopcornHourTools\PopcornHourTools.Tests\bin\Debug\..\..\{0}\dir with no jpg or nfo", testDataLocation)));
            Assert.That(locations.Contains(String.Format(@"G:\Projects\PopcornHourTools\PopcornHourTools.Tests\bin\Debug\..\..\{0}\empty dir", testDataLocation)));
        }
    }
}
