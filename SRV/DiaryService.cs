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
        public Diary Publish(string title, string body, int diaryId)
        {
            Diary diary = new Diary
            {
                Author = new UserRepository().GetById(diaryId),
                Title = title,
                Body = body
            }; 
            diary.Publish();
           return _diaryRepository.Save(diary);


        }
    }
}
