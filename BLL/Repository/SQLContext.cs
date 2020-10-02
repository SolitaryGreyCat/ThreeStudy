using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
   public class SQLContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ThreeStudy;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionstring);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>((optios) => { optios.ToTable("Users")
                .Property(x => x.Name)
                .IsRequired();
            });
        }
    }
  
}
