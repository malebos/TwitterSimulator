using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterSimulator.Domain.Common
{
    internal static class Constants
    {
        internal const int BufferSize = 256;

        internal const string InvalidUserRecord = "Invalid user record";
        internal const string InvalidTweeterRecord = "Invalid tweeter record";
        internal const string ProblemsReadingTweetFile = "Problems reading tweet file";
        internal const string ProblemsReadingUserFile = "Problems reading user file";

        internal const string UsersFilePath = "UsersFilePath";
        internal const string TweetsFilePath = "TweetsFilePath";
            
    }
}
