using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
   public class EmaiRepository:Repository<Email>
    {
        public DbSet<Email> Emails { get; set; }
    }
}
