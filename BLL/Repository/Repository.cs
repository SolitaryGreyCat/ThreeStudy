using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
   public class Repository
    {
       public SQLContext PresentContext { get; set; }
        public Repository()
        {
            PresentContext = new SQLContext();
        }

    }
}
