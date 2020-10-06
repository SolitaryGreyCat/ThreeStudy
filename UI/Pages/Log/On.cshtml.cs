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

namespace UI.Pages.Log
{
    [BindProperties]
    public class OnModel :_LayoutModel
    {
        private const string _userIdKey = "userIdKey";
        private const string _userAuth = "UserAuth";
        UserService _userService;
        public OnModel()
        {
            _userService = new UserService();
        }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "不能为空")]
        public string Password { get; set; }

        public override  void OnGet()
        {
            base.OnGet();
        }
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            UserModel model = _userService.GetUserinfo(UserName);
            if (model == null)
            {
                ModelState.AddModelError("UserName", "用户名不存在");
                return;
            }
            if (!_userService.PasswordCorrect(Password, model.Md5Password))
            {
                ModelState.AddModelError("Password", "用户名或密码错误");
                return;
            }
            //Response.Cookies.Append(_userIdKey, model.Id.ToString());
            //Response.Cookies.Append(_userAuth, model.Md5Password); 
            HttpContext.Session.SetString("UserName",JsonConvert.SerializeObject(model));

        }

    }
}