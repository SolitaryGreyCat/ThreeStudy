using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class UserRepository : Repository
    {

        //private static int _idCounter;//用户ID
        public void Save(User user)
        {
            //_idCounter++;
            //user.Id = _idCounter;
          PresentContext.Users.Add(user);
          PresentContext.SaveChanges();
        }
        public void Save(Email email)
        {
            PresentContext.Emails.Add(email);
            PresentContext.SaveChanges();

        }
        public User GetByName(string userName)
        {

            return PresentContext.Users.Where(u => u.Name == userName).SingleOrDefault();
        }

        public User GetById(int id)
        {
            return PresentContext.Users.Where(u => u.Id == id).SingleOrDefault();
        }

       
    }
}
