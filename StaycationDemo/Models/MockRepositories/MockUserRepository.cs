using System.Collections.Generic;
using System.Linq;
using StaycationDemo.Models.Abstractions;

namespace StaycationDemo.Models.Repositories
{
    //  public class MockUserRepository : IUserRepository
    //  {
    //      public IEnumerable<User> AllUsers() => 
    //          new List<User>
    //          {
    //              new User {FirstName = "Marcus", LastName = "Rashford", Email = "macrash@yahoo.com", Password = "qwed1312**"},
    //              new User {FirstName = "Bukayo", LastName = "Saka", Email = "bursaka@yahoo.com", Password = "98ymhg%"},
    //              new User {FirstName = "Mo", LastName = "Salah", Email = "mosalahb@yahoo.com", Password = "icoi%376"},
    //              new User {FirstName = "Thiago", LastName = "Silva", Email = "thiasil@yahoo.com", Password = "kguyliuho**"}
    //          };

    //      public User GetUserByEmailAndPassword(string email, string password)
    //      {
    //          User user = null;
    //          var allUsers = AllUsers();
    //          foreach (var c in allUsers)
    //          {
    //              if (c.Email == email && c.Password == password)
    //                  user = c;
    //          }
    //          return user;                                                                                                                                                                                                                                                                                                                                                                                                            
    //      }

    //      public bool SaveCustomer(User customer)
    //      {
    //          bool isSaved = false;
    //          var allUsers = AllUsers();
    //          foreach (var c in allUsers)
    //	{
    //              if (customer.Email == c.Email) return isSaved;

    //	}
    //          allUsers.Append(customer);
    //	isSaved = true;
    //	return isSaved;
    //}
    //  }
    // Couldn't implement Mockdbs because added async.
}
