using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public class DbUserRepository : DbContext
        {
            public DbUserRepository():base("17bang")
            {

            }
            public DbSet<Student> students { get; set; }
            public void Save(Student User)
            {
                students.Add(User);
                SaveChanges();
        }

            public Student GetByName(string username)
            {
                return students.Where(u=>u.Name == username).SingleOrDefault();
            }
        }
    }
       

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
