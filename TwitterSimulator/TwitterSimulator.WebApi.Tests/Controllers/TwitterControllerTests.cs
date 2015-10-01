using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterSimulator.WebApi.Controllers;
using TwitterSimulator.WebApi.Tests.Mocks;

namespace TwitterSimulator.WebApi.Tests.Controllers
{

    [TestClass]
    public class TwitterControllerTests
    {
        [TestMethod]
        public void  GetTweets_WhereTweetsExists_RetunsUserTweetsJsonResults()
        {
            TwitterController controller = new TwitterController(new UserServiceMock(), new TweetServiceMock());
           
            var results = controller.GetTweets();

            Assert.AreEqual("Joe", results[0].Name);
            Assert.AreEqual(4, results[0].Tweets.Count);
            Assert.AreEqual("I like running", results[0].Tweets[1].Message);
            Assert.AreEqual("Nothing is impossible.", results[0].Tweets[2].Message);

            Assert.AreEqual("Sue", results[1].Name);
            Assert.AreEqual(3, results[1].Tweets.Count);
            Assert.AreEqual("I like running", results[1].Tweets[1].Message);
            Assert.AreEqual("The earth is round.", results[1].Tweets[2].Message);
           
        }
    }
}
