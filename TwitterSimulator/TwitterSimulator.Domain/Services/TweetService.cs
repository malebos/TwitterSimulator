using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.Domain.Factories;
using TwitterSimulator.Domain.FileReaders;
using TwitterSimulator.Domain.Interfaces;

namespace TwitterSimulator.Domain.Services
{
    public class TweetService : ITweetService
    {
        public List<Tweet> GetTweets(string path = "")
        {  
            var fileReader = new TweetFileReader(path);
            var results = fileReader.Read();
            return results;

        }
    }
}
