using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterSimulator.Domain.Entities
{
    public class User
    {
        public User()
        {
            Followees = new List<string>();
        }

        public User(string name, List<string> followees)
        {
            Name = name;
            Followees = followees;
        }

        public string Name { set; get; }
        public List<string> Followees { set; get; }
    }
}
