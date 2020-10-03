
using BLL;
using BLL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbFactory
{
    internal class RegisterFactory
    {
        internal static User ZhaoYun, MaChao;
        private static UserRepository _userRepository;
        static RegisterFactory()
        {
            _userRepository = new UserRepository(); 
        }
        internal static void Create()
        {
            ZhaoYun = Register("赵云");
            MaChao = Register("马超");

           

        }
        private static User Register(string name)
        {
            User user = new User { Name = name, Password = Assist.PASSWORD };
            user.Register();
            _userRepository.Save(user);
            return user;
        }
    }
}
