using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Loggings;
using TwitterSimulator.Domain.Common.Exceptions;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.Domain.Factories;


namespace TwitterSimulator.Domain.FileReaders
{
    internal class TweetFileReader
    {
        private readonly TweetFactory _factory;
        private readonly string _path;

      
        internal TweetFileReader(string folderPath = "")
        {
            _path = Path.Combine(folderPath, ConfigurationManager.AppSettings[Constants.TweetsFilePath]);
            _factory = new TweetFactory();
        }

        internal virtual List<Tweet> Read()
        {
            try
            {
                var results = new List<Tweet>();

                using (var fileStream = File.OpenRead(_path))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.ASCII, true, Constants.BufferSize))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var tweet = _factory.Create(streamReader.ReadLine());

                            results.Add(tweet);
                        }
                    }
                }

                return results;
            }
            catch(DomainException domainEx)
            {
                throw domainEx;
            }
            catch (Exception ex)
            {
                Error.Log(Constants.ProblemsReadingTweetFile, ex);
                throw  new DomainException(Constants.ProblemsReadingTweetFile, ex);
            }
        }
    }
}
