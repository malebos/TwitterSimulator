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
    public class UserFactory
    {
        public User Create(string lineFeed)
        {
            try
            {
                var user = new User();

                var userFields = lineFeed.Split(new string[]{"follows"}, StringSplitOptions.RemoveEmptyEntries);
                user.Name = userFields[0].Trim();

                var followers = userFields[1].Split(',');
                foreach(var follow in followers)
                    user.Followees.Add(follow.Trim());

                return user;
            }
            catch(IndexOutOfRangeException ex)
            {
                Error.Log(Constants.InvalidUserRecord, ex);
                throw new DomainException(Constants.InvalidUserRecord, ex);
            }
        }
    }
}
