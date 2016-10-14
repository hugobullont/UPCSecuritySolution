using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BusinessLogic.UserService;
using DataAccess.UserRepository;

namespace BusinessLogic.UserService
{
    public class UserService : IUserService
    {
        public void DeleteUser(int userId)
        {
            IUserRepository repository = new UserRepository();
            repository.DeleteUser(userId);
        }

        public void NewUser(User user)
        {
            IUserRepository repository = new UserRepository();
            repository.NewUser(user);
        }

        public string TypeUser(string userName, string password)
        {
            IUserRepository repository = new UserRepository();
            return repository.TypeUser(userName, password);
        }

        public void UpdateUser(User user)
        {
            IUserRepository repository = new UserRepository();
            repository.UpdateUser(user);
        }
    }
}
