using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SRV;

namespace UI.Pages.Diary
{
    [BindProperties]
    public class PublishModel : _LayoutModel
    {
        public Diary Diary{ get; set; }
        private DiaryService _diaryService;
        public PublishModel()
        {
            _diaryService = new DiaryService();
        }
        public override void OnGet()
        {
            base.OnGet();
        }
       public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            _diaryService.Publish(Diary.Title, Diary.Body);
        }

        
    }
    public class Diary
    {
        public String Title { get; set; }
        [DataType(DataType.Text)]
        public String Body { get; set; }


    }
}