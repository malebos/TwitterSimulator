using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.WebApi.Mappers;

namespace TwitterSimulator.WebApi.Tests.Mappers
{
  
    [TestClass]
    public class UserTweetsMapperTests
    {
        //Method name conversion : MethodName_Clause_Results

        [TestMethod]
        public void MapToUserTweets_WhereParamteersAreValid_ReturnsUserTweetsList()
        {
            var user = new User();
            user.Name = "Tom";
            user.Followees = new List<string>() {"Mary", "Tom", "Sue" };
            var tweets = new List<Tweet>();
            tweets.Add(new Tweet() { Name = "Sue", Message = "I love programming." });
            tweets.Add(new Tweet() { Name = "Tom", Message = "Great weather outside!" });
            tweets.Add(new Tweet() { Name = "Jane", Message = "I love my red socks." });
            tweets.Add(new Tweet() { Name = "Tom", Message = "Nothing travels faster than speed of light" });
            tweets.Add(new Tweet() { Name = "Mary", Message = "Mary has a little lamb" });

            var results = UserTweetMapper.MapToUserTweets(user, tweets);


            Assert.AreEqual(4, results.Tweets.Count);
            Assert.AreEqual("Tom", results.Name);
            Assert.AreEqual("Great weather outside!", results.Tweets[1].Message);
            Assert.AreEqual("Mary has a little lamb", results.Tweets[3].Message);

        }
    }
}
