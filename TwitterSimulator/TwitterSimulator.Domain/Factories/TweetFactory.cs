using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Loggings;
using TwitterSimulator.Domain.Common.Exceptions;
using TwitterSimulator.Domain.Entities;

namespace TwitterSimulator.Domain.Factories
{
    internal class TweetFactory
    {
        internal Tweet Create(string lineFeed)
        {
            try
            {
                var tweet = new Tweet();
                var tweetFields = lineFeed.Split(new string[]{"> "}, StringSplitOptions.None);
                tweet.Name = tweetFields[0].Trim();
                tweet.Message = tweetFields[1];

                return tweet;

             }
            catch(IndexOutOfRangeException ex)
            {
                Error.Log(Constants.InvalidTweeterRecord, ex);
                throw new DomainException(Constants.InvalidTweeterRecord, ex);
            }
        }
    }
}
