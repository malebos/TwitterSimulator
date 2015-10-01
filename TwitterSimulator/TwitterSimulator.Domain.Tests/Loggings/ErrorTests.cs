using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterSimulator.Domain.Common.Loggings;

namespace TwitterSimulator.Domain.Tests.Loggings
{
    [TestClass]
    public class ErrorTests
    {
        //Method name conversion : MethodName_Clause_Results

        [TestMethod]
        public void Log_WhereInnerExceptionIsNested_ReturnsExceptionsAndTrace()
        {
            var firstException = new ExecutionEngineException("Internal workings failed");
            var secondException = new ArgumentOutOfRangeException("Unable to continue.", firstException);
            var thirdException = new ArgumentNullException("Argument not set", secondException);

            var actualResults = Error.GetAllInnerExceptions(thirdException);
           
            StringBuilder expectedResults = new StringBuilder();
            expectedResults.Append("System.ArgumentOutOfRangeException: Unable to continue. ---> ");
            expectedResults.Append("System.ExecutionEngineException: Internal workings failed\r\n   --- ");
            expectedResults.Append("End of inner exception stack trace ---\r\n");
            expectedResults.Append("No Stack trace recorded.\r\n");

            Assert.AreEqual(expectedResults.ToString(), actualResults);


        }
    }
}
