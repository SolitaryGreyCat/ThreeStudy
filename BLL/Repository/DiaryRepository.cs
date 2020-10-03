using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public class DiaryRepository : Repository
    {
             
        public Diary Save(Diary diary)
        {
            PresentContext.Add(diary);
           PresentContext.SaveChanges();
            return diary;
        }
    }
}
