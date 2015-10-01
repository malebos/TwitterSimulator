using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Entities;
using TwitterSimulator.Domain.Factories;
using TwitterSimulator.Domain.FileReaders;
using TwitterSimulator.Domain.Interfaces;

namespace TwitterSimulator.Domain.Services
{
    public class UserService : IUserService
    {
        public IEnumerable<User> GetUsers(string path ="")
        {
            UserFileReader fileReader = new UserFileReader(path);
            var users = fileReader.Read();

            AppendUsersWithNoFollowers(users);

            return users.OrderBy(x => x.Key).Select(x => new User(x.Key, x.Value));
        }

        public void AppendUsersWithNoFollowers(Dictionary<string, List<string>> users)
        {
            var usersToAppend = new List<string>();
            foreach(var followees in users.Values)
            {
                foreach (var followee in followees)
                {
                    if (!users.ContainsKey(followee))
                        usersToAppend.Add(followee);
                }
            }
            usersToAppend.ForEach(x => { if(!users.ContainsKey(x))   users.Add(x, new List<string>());  } );
        }
       
    }
}
