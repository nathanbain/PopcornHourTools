using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PopcornHourTools.Tests.CollectionUtils
{
    public class ResultFinderTests
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
    }
}
