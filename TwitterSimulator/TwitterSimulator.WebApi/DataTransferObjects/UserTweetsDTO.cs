using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterSimulator.WebApi.DataTransferObjects
{
    [DataContract]
    public class UserTweetsDTO
    {
        public UserTweetsDTO()
        {
            Tweets = new List<UserTweetDTO>();
        }

        [DataMember]
        public string Name { set; get; }
        [DataMember]
        public List<UserTweetDTO> Tweets { set; get; }
    }
}
