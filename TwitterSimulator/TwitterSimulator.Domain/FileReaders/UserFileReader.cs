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
    internal class UserFileReader
    {
        private readonly UserFactory _factory;
        private readonly string _path;

        internal UserFileReader(string folderPath = "")
        {
            _path = Path.Combine(folderPath, ConfigurationManager.AppSettings[Constants.UsersFilePath]);
            _factory = new UserFactory();
        }

        internal virtual Dictionary<string, List<string>> Read()
        {
            try
            { 
                var users = new Dictionary<string, List<string>>();

                using (var fileStream = File.OpenRead(_path))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.ASCII, true, Constants.BufferSize))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var user = _factory.Create(streamReader.ReadLine());

                            if (users.ContainsKey(user.Name))
                                users[user.Name].AddRange(user.Followees);
                            else
                                users.Add(user.Name, user.Followees);
                        }
                    }
                }
                return users;
            }
            catch (DomainException domainEx)
            {
               
                throw domainEx;
            }
            catch (Exception ex)
            {
                Error.Log(Constants.ProblemsReadingUserFile, ex);
                throw new DomainException(Constants.ProblemsReadingUserFile, ex);
            }
        }
    }

       
}
