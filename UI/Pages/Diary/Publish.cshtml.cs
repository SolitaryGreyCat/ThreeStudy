using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SRV;
using SRV.Model;

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
           
            UserModel CurrentUser = JsonConvert.DeserializeObject<UserModel>(
                HttpContext.Session.GetString("UserName")
            );
            _diaryService.Publish(Diary.Title, Diary.Body,CurrentUser.Id);
        }

        
    }
    public class Diary
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }


    }
}