using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class UserRepository : Repository<User>
    {
        public DbSet<User> Emails { get; set; }


        public User GetByName(string userName)
        {

            return entities.Where(u => u.Name == userName).SingleOrDefault();
        }

        public User GetById(int id)
        {
            return entities.Where(u => u.Id == id).SingleOrDefault();
        }

       
    }
}
