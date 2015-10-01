using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.Domain.Interfaces;

namespace TwitterSimulator.WebApi.Tests.Mocks
{
    public class TweetServiceMock :ITweetService
    {

        public List<Tweet> GetTweets(string path = "")
        {
            return new List<Tweet>(){ new Tweet(){Name="Sue", Message= "It is sunny day!"},
                                     new Tweet(){Name="Joe",  Message= "I like running"},
                                     new Tweet(){Name="Tom",  Message= "Nothing is impossible."},
                                     new Tweet(){Name="Sue",  Message= "The earth is round."}};
        }
    }
}
