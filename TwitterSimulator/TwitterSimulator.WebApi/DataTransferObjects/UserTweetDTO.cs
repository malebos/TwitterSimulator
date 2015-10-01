using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TwitterSimulator.WebApi.DataTransferObjects
{
    [DataContract]
    public class UserTweetDTO
    {
        public UserTweetDTO(string name, string message)
        {
            Name = name;
            Message = message;
        }

        [DataMember]
        public string Name { set; get; }
        [DataMember] 
        public string Message { set; get; }
    }
}