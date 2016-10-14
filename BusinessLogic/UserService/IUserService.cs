using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.UserService
{
    public interface IUserService
    {
        void NewUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        string TypeUser(string userName, string password);
    }
}
