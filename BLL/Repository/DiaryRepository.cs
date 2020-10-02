using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repository
{
    public class DiaryRepository
    {
        private SQLContext _sqlContext;
        public DiaryRepository()
        {
            _sqlContext = new SQLContext();
        }
        
        public void Save(Diary diary)
        {
            _sqlContext.Add(diary);
            _sqlContext.SaveChanges();
        }
    }
}
