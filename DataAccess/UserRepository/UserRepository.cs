using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public void DeleteUser(int userId)
        {
            using (var model = new UPCSecurityEntities())
            {
                User objUser = model.Users.Find(userId);
                if(objUser!= null)
                {
                    model.Users.Remove(objUser);
                    model.SaveChanges();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            UPCSecurityEntities UPCModel = new UPCSecurityEntities();
            List<User> users = (from c in UPCModel.Users select c).ToList();
            return users;
        }

        public User GetUser(string userName, string password)
        {
            UPCSecurityEntities UPCModel = new UPCSecurityEntities();
            var userV = from c in UPCModel.Users
                        where c.Username == userName && c.Password == password
                        select c;
            User user = userV.FirstOrDefault();
            return user;
        }

        public void NewUser(User user)
        {
            using (var model = new UPCSecurityEntities())
            {
                model.Users.Add(user);
                model.SaveChanges(); 
            }
        }


        public string TypeUser(string userName, string password)
        {
            using (var model = new UPCSecurityEntities())
            {
                var newUser = from c in model.Users
                           where c.Username == userName && c.Password == password
                           select c;
                
                    User user = newUser.FirstOrDefault();
                if (user != null)
                {
                    return user.UserType;
                }
                else
                {
                    return "null";
                }
            }
        }

        public void UpdateUser(User user)
        {
            using (var model = new UPCSecurityEntities())
            {
                var original = model.Users.Find(user.idUser);

                if (original != null)
                {
                    model.Entry(original).CurrentValues.SetValues(user);
                    model.SaveChanges();
                }
            }
        }
    }
}
