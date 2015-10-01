using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TwitterSimulator.Domain.Services;
using System.Collections.Generic;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Exceptions;

namespace TwitterSimulator.Domain.Integration.Tests.Services
{
    [TestClass]
    public class TweetServiceTests
    {
        [TestMethod]
        [Description("Integration")]
        public void GetTweets_ValidTweetFile_ReturnsListOfTweeets()
        {
            string directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            TweetService tweetService = new TweetService();

            List<Tweet> results = tweetService.GetTweets(directoryPath);

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("Alan", results[0].Name);
        }

        [TestMethod]
        [Description("Integration")]
        [ExpectedException(typeof(DomainException), Constants.ProblemsReadingTweetFile)]
        public void GetTweets_WrongTweetFile_ReturnsException()
        {
            string directoryPath = "x:\\WrongFilePath";
            TweetService tweetService = new TweetService();

            tweetService.GetTweets(directoryPath);
        }
    }
}
