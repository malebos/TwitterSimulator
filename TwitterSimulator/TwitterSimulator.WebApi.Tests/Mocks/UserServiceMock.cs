using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.Domain.Interfaces;

namespace TwitterSimulator.WebApi.Tests.Mocks
{
    public class UserServiceMock : IUserService
    {
        public IEnumerable<User> GetUsers(string path = "")
        {
            return new List<User>() { new User("Joe", new List<string> { "Sue", "Tom" }),
                                      new User("Sue", new List<string> { "Joe" })};
        }
    }
}
