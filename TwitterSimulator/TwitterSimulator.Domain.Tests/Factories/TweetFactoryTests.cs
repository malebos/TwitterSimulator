using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Exceptions;
using TwitterSimulator.Domain.Factories;

namespace TwitterSimulator.Domain.Tests.Factories
{
    [TestClass]
    public class TweetFactoryTests
    {
        //Method name conversion : MethodName_Clause_Results

        [TestMethod]
        public void TweetFactory_InputIsValid_ReturnsInstance()
        {
            string lineFeed = "Alan> Good Morning.";

            TweetFactory factory = new TweetFactory();
            var result = factory.Create(lineFeed);

            Assert.AreEqual("Alan", result.Name);
            Assert.AreEqual("Good Morning.", result.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException), Constants.InvalidTweeterRecord)]
        public void TweetFactory_InputIsNotValid_ReturnsException()
        {
            string lineFeed = "Alan>";

            TweetFactory factory = new TweetFactory();
            var result = factory.Create(lineFeed);
        }
    }
}
