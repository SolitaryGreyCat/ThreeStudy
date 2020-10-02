using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class Diary
    {
        public int Diaryid { get; set; }
        public string Title { get; set; }
        public string body { get; set; }
        public DateTime PublishTime { get; set; }
        public User user { get; set; }
       
    }
}
