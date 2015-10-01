using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterSimulator.Domain.Services;
using System.Collections.Generic;

namespace TwitterSimulator.Domain.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        //Method name conversion : MethodName_Clause_Results

        [TestMethod]
        public void AppendUsersWithNoFollowers_WhereUsersWithNoFollowersExists_AppendsToTheDictionary()
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            users.Add("User1", new List<string>(){"User2", "User3"});
            users.Add("User2", new List<string>(){"User1", "Followee"});
            users.Add("User3", new List<string>() { "User1", "User2" });

            var userService = new UserService();
            userService.AppendUsersWithNoFollowers(users);
            
            Assert.AreEqual(4,users.Count);
            Assert.AreEqual(0, users["Followee"].Count);

        }


        [TestMethod]
        public void AppendUsersWithNoFollowers_WhereAllUsersHaveFollowers_DictionaryDoesNotChange()
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            users.Add("User1", new List<string>() { "User2", "User3" });
            users.Add("User2", new List<string>() { "User1", "User3" });
            users.Add("User3", new List<string>() { "User1", "User2" });

            var userService = new UserService();
            userService.AppendUsersWithNoFollowers(users);

            Assert.AreEqual(3, users.Count);

        }
    }
}
