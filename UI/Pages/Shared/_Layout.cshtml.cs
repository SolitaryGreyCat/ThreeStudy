using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SRV;
using SRV.Model;

namespace UI.Pages
{
    public class _LayoutModel : PageModel
    {
        protected const string userIdKey = "userIdKey";
        protected const string userAuthKey = "userAuth";

        public virtual void OnGet()
        {
            //ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            //cookie µœ÷
            //if (Request.Cookies.TryGetValue(userIdKey,out string uerIdValue))
            //{
            //    UserModel model = new UserService().GetById(Convert.ToInt32(uerIdValue));
            //    if (model!=null)
            //    {
            //        if (Request.Cookies.TryGetValue(userAuthKey,out string userAuthValue))
            //        {
            //            if (userAuthValue == model.Md5Password)
            //            {
            //                ViewData["UserName"] = model.Name;
            //                Response.Redirect("/Index");
            //            }
            //        }
            //    }
            //}
        }
       
        public int? CurrentUserId
        {
            get
            {
                string UserOfSession = HttpContext.Session.GetString("UserName");
                if (string.IsNullOrEmpty(UserOfSession))
                {
                    return null;
                }
                return JsonConvert.DeserializeObject<UserModel>(UserOfSession).Id;
            }
        }
    }
}
