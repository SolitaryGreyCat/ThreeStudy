using BLL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace DbFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //DatabaseFacade db = new SQLContext().Database;
            //db.EnsureDeleted();
            //db.EnsureCreated();
            RegisterFactory.Create();
            Console.WriteLine();


        }
    }
}
