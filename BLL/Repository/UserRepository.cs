using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class UserRepository 
    {
        private SQLContext _sqlContext;
        public UserRepository()
        {
            _sqlContext = new SQLContext();
        }
        //private static int _idCounter;//用户ID
        public void Save(User user)
        {
            //_idCounter++;
            //user.Id = _idCounter;
          _sqlContext.Users.Add(user);
          _sqlContext.SaveChanges();
        }
        public void Save(Email email)
        {
            _sqlContext.Emails.Add(email);
            _sqlContext.SaveChanges();

        }
        public User GetByName(string userName)
        {

            return _sqlContext.Users.Where(u => u.Name == userName).SingleOrDefault();
        }

        public User GetById(int id)
        {
            return _sqlContext.Users.Where(u => u.Id == id).SingleOrDefault();
        }

       
    }
}
