using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class DbUserRepository : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Person;Integrated Security=True;");
            }
            public DbSet<Student> students { get; set; }
            public void Save(Student User)
            {
                students.Add(User);
                SaveChanges();
            }

            public Student GetByName(string username)
            {
              var  Resualt =  students.Where(u => u.Name == username).Include(u=>u.Name);
                return Resualt.SingleOrDefault();
            }
            public Student  GetById(int id)
            {
                return students.Where(u => u.Id > id).SingleOrDefault();
            }
        }
    }


    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

