using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TwitterSimulator.Domain.FileReaders;
using System.Collections.Generic;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Exceptions;

namespace TwitterSimulator.Domain.Integration.Tests.FileReaders
{
    [TestClass]
    public class UserFileReaderTests
    {

        [TestMethod]
        [Description("Integration")]
        public void Read_ValidUserFile_ReturnsDictionaryOfUsers()
        {
            string directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            UserFileReader fileReader = new UserFileReader(directoryPath);

            Dictionary<string,List<string>> results = fileReader.Read();

            Assert.AreEqual(2, results.Count);
            Assert.IsFalse(results.ContainsKey("Martin"));
            Assert.IsTrue(results["Ward"].Contains( "Martin"));
        }

        [TestMethod]
        [Description("Integration")]
        [ExpectedException(typeof(DomainException), Constants.ProblemsReadingUserFile)]
        public void Read_WrongUserFilePath_ReturnsException()
        {
            string directoryPath = "x:\\WrongFilePath";
            UserFileReader fileReader = new UserFileReader(directoryPath);

            fileReader.Read();
        }
    }
}
