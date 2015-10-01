using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterSimulator.Domain.Factories;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Exceptions;


namespace TwitterSimulator.Domain.Tests.Factories
{
    [TestClass]
    public class UserFactoryTests
    {
        //Method name conversion : MethodName_Clause_Results

        [TestMethod]
        public void UserFactory_InputIsValid_ReturnsInstance()
        {
            string lineFeed = "Ward follows Martin, Alan";

            UserFactory factory = new UserFactory();
            var result = factory.Create(lineFeed);

            Assert.AreEqual("Ward",result.Name);
            Assert.AreEqual(2, result.Followees.Count);
            Assert.AreEqual("Martin",result.Followees[0]);
            Assert.AreEqual("Alan",result.Followees[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException), Constants.InvalidUserRecord)]
        public void UserFactory_InputIsNotValid_ReturnsException()
        {
            string lineFeed = "Ward follows";

            UserFactory factory = new UserFactory();
            var result = factory.Create(lineFeed);
        }
    }
}
