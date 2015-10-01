using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwitterSimulator.Domain.Common;
using TwitterSimulator.Domain.Common.Loggings;
using TwitterSimulator.WebApi.Attributes;
using TwitterSimulator.WebApi.DataTransferObjects;
using TwitterSimulator.WebApi.Mappers;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.Domain.Services;
using TwitterSimulator.Domain.Interfaces;

namespace TwitterSimulator.WebApi.Controllers
{
    [AllowCrossSiteJsonAttribute]
    public class TwitterController : ApiController
    {
        ITweetService _tweetService;
        IUserService _userService;

        public TwitterController()
        {
            _tweetService = new TweetService();
            _userService = new UserService();
        }

        public TwitterController(IUserService userService, ITweetService tweetService)
        {
            _tweetService = tweetService;
            _userService = userService;
        }

        // GET WebApi/GetTweets
        public List<UserTweetsDTO> GetTweets()
        {
            try
            {
                var tweets = _tweetService.GetTweets();
                var users = _userService.GetUsers();

                var results = new List<UserTweetsDTO>();
                foreach (var user in users)
                {
                    var userTweets = UserTweetMapper.MapToUserTweets(user, tweets);
                    results.Add(userTweets);
                }

                return results;
             }
            catch (DomainException domainEx)
            {
                throw domainEx;
            }
            catch(Exception ex)
            {
                Error.Log(Constants.ProblemGettingUserTweets, ex);
                throw new Exception(Constants.ProblemGettingUserTweets, ex);
            }
        }
    }
}
