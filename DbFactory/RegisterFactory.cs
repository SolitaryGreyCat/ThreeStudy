using SRV;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbFactory
{
    internal class RegisterFactory
    {
        private static UserService _userService;
        static RegisterFactory()
        {
            _userService = new UserService();
        }
        internal static void Create()
        {
            _userService.Register("张飞", Assist.PASSWORD);
            _userService.Register("赵云", Assist.PASSWORD);

        }
    }
}
