using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterSimulator.Domain.Entities;

namespace TwitterSimulator.Domain.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(string path = "");
    }
}
