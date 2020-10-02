using BLL;
using BLL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRV
{
    public class DiaryService
    {
        private DiaryRepository _diaryRepository;
        public DiaryService()
        {
            _diaryRepository = new DiaryRepository();
        }
        public void Publish(string title, string body)
        {
            Diary diary = new Diary();
            diary.Title = title;
            diary.body = body;
            _diaryRepository.Save(diary);
            
        }
    }
}
