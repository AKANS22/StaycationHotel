using System.IO;
using System;
using StaycationDemo.Models.Abstractions;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace StaycationDemo.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static string path = Path.Combine(Environment.CurrentDirectory, "db");
        private static readonly string userDb = Path.Combine(path, "users.json");

        public IEnumerable<User> AllUsers()
        {
            List<User> allUsers = null;
            bool exists = File.Exists(userDb);
            if (exists && new FileInfo(userDb).Length != 0)
            {
                var readText = File.ReadAllLines(userDb);
                allUsers = JsonConvert.DeserializeObject<List<User>>(readText[0], new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            }
            return allUsers;
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            User user = null;
            var allUsers = AllUsers();
            if (allUsers != null)
            {
                foreach (var c in allUsers)
                {
                    if (c.Email == email || c.Password == password)
                        user = c;
                }
            }
            
            return user;
        }

        public bool SaveCustomer(User user)
        {
            bool isSaved = false;
            var allUsers = AllUsers();
            if (allUsers != null)
            {
                foreach (User c in allUsers)
                {
                    if (c.Email == user.Email)
                    {
                        return isSaved;
                    }
                    allUsers = allUsers.Append(user);
                }
            }
            else
            {
                allUsers = new List<User> { user };
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(userDb, JsonConvert.SerializeObject(allUsers, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
            isSaved = true;
            return isSaved;
        }
    }
}
