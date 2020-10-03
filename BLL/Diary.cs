using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class Diary
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishTime { get; set; }

        public void Publish()
        {
            PublishTime = DateTime.Now;
        }
    }
}
