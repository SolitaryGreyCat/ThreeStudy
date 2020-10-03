using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
   public class Repository<T> where T : class
    {
       public SQLContext PresentContext { get; set; }
        protected DbSet<T> entities;
        public Repository()
        {
            PresentContext = new SQLContext();
            entities = PresentContext.Set<T>();
            
        }
        public T Save(T enyity)
        {
           entities.Add(enyity);
            PresentContext.SaveChanges();
            return enyity;
        }


       
    }
}
