using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitterSimulator.WebApi.DataTransferObjects;
using TwitterSimulator.Domain.Entities;

namespace TwitterSimulator.WebApi.Mappers
{
    internal class UserTweetMapper
    {
        internal static UserTweetsDTO MapToUserTweets(User user, List<Tweet> tweets)
        {
            var allUserTweets = tweets.Select(x => new UserTweetDTO(x.Name, x.Message))
                                          .Where(x => user.Followees.Contains(x.Name) ||
                                                      user.Name == x.Name);

            var userTweets = new UserTweetsDTO();
            userTweets.Name = user.Name;
            userTweets.Tweets.AddRange(allUserTweets);
            return userTweets;
        }
    }
}