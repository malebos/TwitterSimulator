using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterSimulator.Domain.Common.Loggings
{
    public class Error
    {
        public static void Log(string message, Exception ex)
        {
            Trace.WriteLine(string.Format("{3}{0} :   Message : {1}{3}{2}", DateTime.Now.ToShortDateString(), message, GetAllInnerExceptions(ex), Environment.NewLine));
        }

        internal static string GetAllInnerExceptions(Exception exception, StringBuilder errors = null, int innerExceptionsCount = 0)
        {
            innerExceptionsCount++;

            if(errors == null)
                errors = new StringBuilder();

            if (exception.InnerException != null && innerExceptionsCount < 10)
            {
                errors.AppendLine(exception.InnerException.ToString());
                GetAllInnerExceptions(exception.InnerException.InnerException);
            }

            errors.AppendLine(exception.StackTrace ?? "No Stack trace recorded.");
            return errors.ToString();
        }
    }
}
