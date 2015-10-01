using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Exceptions;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.Domain.FileReaders;

namespace TwitterSimulator.Domain.Integration.Tests
{
    [TestClass]
    public class TweetFileReaderTests
    {
        //Method name conversion : MethodName_Clause_Results

       [TestMethod]
       [Description("Integration")]
       public void Read_ValidTweetFile_ReturnsListOfTweeets()
       {
            string directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            TweetFileReader fileReader = new TweetFileReader(directoryPath);

            List<Tweet> results = fileReader.Read();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("Alan", results[0].Name);
        }

       [TestMethod]
       [Description("Integration")]
       [ExpectedException(typeof(DomainException), Constants.ProblemsReadingTweetFile)]
       public void Read_WrongTweetFilePath_ReturnsException()
       {
           string directoryPath = "x:\\WrongFilePath";
           TweetFileReader fileReader = new TweetFileReader(directoryPath);

          fileReader.Read();
       }
    }
}
