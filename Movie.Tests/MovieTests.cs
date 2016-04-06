using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Movie.Tests
{
    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        public void CanParseNetflixFeed()
        {
            var feed = Netflix.parseTop100(XDocument.Load("NetflixSearch.xml").Root.ToString());
            Assert.AreEqual(100, feed.Count());

            var first = feed.First();
            Assert.AreEqual("The Martian", first.Title);
            Assert.AreEqual("http://cdn-0.nflximg.com/us/boxshots/small/80058399.jpg", first.Thumbnail.Value);
        }

        [TestMethod]
        public void CanParseNYTReviews()
        {
            var json = File.ReadAllText("NYTimes.json");
            var read = NYTimes.tryPickReviewByName("Vita Activa: The Spirit of Hannah Arendt", json);
        }
    }
}
