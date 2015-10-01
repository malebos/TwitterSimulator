using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterSimulator.Domain.Services;
using System.IO;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Exceptions;

namespace TwitterSimulator.Domain.Integration.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        [Description("Integration")]
        public void GetUsers_WhereParametersAreValid_ReturnsAlphabeticalListOfUsers()
        {
           string directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
           var userService = new UserService();

           var results = userService.GetUsers(directoryPath).ToList();

            Assert.AreEqual(3, results.Count);

            Assert.AreEqual("Martin",results[1].Name);
            Assert.AreEqual(0, results[1].Followees.Count);

            Assert.AreEqual("Ward", results[2].Name);
            Assert.IsTrue(results[2].Followees.Contains("Alan"));
        }

        [TestMethod]
        [Description("Integration")]
        [ExpectedException(typeof(DomainException), Constants.ProblemsReadingUserFile)]
        public void GetUsers_WrongUserFilePath_ReturnsException()
        {
            string directoryPath = "x:\\WrongFilePath";
            UserService userService = new UserService();

            userService.GetUsers(directoryPath);
        }
    }
}
