using Bidone.CodingTest.Application.Common.Interfaces;
using Bidone.CodingTest.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidone.CodingTest.Infrastructure.Files
{
    public class FileStorageService : IFileStorageService
    {
        private static readonly JsonSerializerSettings _options = new() { NullValueHandling = NullValueHandling.Ignore };
        public void BuildOutputFile(User record, string fileName)
        {
            List<User>? users = this.ReadOutputFile(fileName)?.ToList();
            if (users != null)
            {
                users.Add(record);
            }
            else
            {
                users = new List<User> { record };
            }
            var jsonString = JsonConvert.SerializeObject(users, _options);
            File.WriteAllText(fileName, jsonString);
        }
        public IEnumerable<User> ReadOutputFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                return null;
            }
            var stringContent = File.ReadAllText(fileName);
            IEnumerable<User>? users = JsonConvert.DeserializeObject<IEnumerable<User>>(stringContent);
            return users;
        }
    }
}
