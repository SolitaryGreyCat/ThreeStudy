using System;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Email Email { get; set; }
        public void Register()
        {
            //注册成功，返回信息；
            //将用户信息持久化
            Password = GetMd5Hash(Password);

        }
       public static string GetMd5Hash( String input)
        {
            /// <summary>
            /// 密码加密常量，请勿修改。
            /// </summary>
            const string _salt = "ThreeStudy";
            using (MD5 md5Hash = MD5.Create())
            {               
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input + _salt));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }

        }
    }
}
