using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.UserRepository
{
    public interface IUserRepository
    {
        void NewUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        string TypeUser(string userName, string password);
        List<User> GetAllUsers();
        User GetUser(string userName, string password);
    }
}
