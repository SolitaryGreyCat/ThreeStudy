using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SRV;

namespace UI.Pages
{
    [BindProperties]
    public class RegisterModel : _LayoutModel
    {
        private UserService _userService;
        public RegisterModel()
        {
            _userService = new UserService();
        }
        public Register Register { get; set; }

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
            if (_userService.HasExist(Register.UserName))
            {
                ModelState.AddModelError("Register.UserName", "*用户名已经存在");
                return;
            }
            _userService.Register(Register.UserName, Register.PassWord);

           

        }





    }

    public class Register
    {


        [Display(Name = "用户名")]
        [MaxLength(10, ErrorMessage = "用户名长度不能大于10")]
        [MinLength(2, ErrorMessage = "* 用户名长度不能小于2")]
        public string UserName { get; set; }

        [Display(Name = "用户名")]
        [MaxLength(16, ErrorMessage = "用户名密码长度不能大于16")]
        [MinLength(6, ErrorMessage = "* 用户名密码不能小于6")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }


        [Display(Name = "确认密码")]
        [Compare("PassWord", ErrorMessage = "两次输入密码不一致")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //[YQBRequired]
        //[Display(Name ="验证码")]
        //public string Captcha { get; set; }
    }
}