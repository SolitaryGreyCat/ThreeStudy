using BLL;
using BLL.Repository;
using SRV.Model;
using System;

namespace SRV
{
    public class UserService
    {
        private UserRepository _userRepostory;
        public UserService()
        {
            _userRepostory = new UserRepository();
        }
        public void Register(string username, string password)
        {
            User user = new User();
            user.Name = username;
            user.Password = password;
            user.Register();
            _userRepostory.Save(user);
        }

        public bool Hasrepetition(string userName)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            User user = _userRepostory.GetById(id);
            if (user == null)
            {
                return null;
            }
            else
            {
                UserModel model = new UserModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Md5Password = user.Password

                };
                return model;
            }
        }

        public void SendValidationEmail(string emailAddress, string validationUrlFormat)
        {
            Email email = new Email { Address = emailAddress };
            _userRepostory.Save(email);
            string validationUrl = string.Format(validationUrlFormat, email.Id, email.ValidationCode);
        }

        public bool PasswordCorrect(string password, string Md5Password)
        {
            return User.GetMd5Hash(password) == Md5Password;
        }

        public UserModel GetUserinfo(string userName)
        {
            User user = _userRepostory.GetByName(userName);
            if (user == null)
            {
                return null;
            }
            else
            {
                UserModel model = new UserModel();
                model.Id = user.Id;
                model.Name = user.Name;
                model.Md5Password = user.Password;
                return model;
            }

        }

        public bool HasExist(string userName)
        {
            return _userRepostory.GetByName(userName) != null;
            

        }
    }
    //public class UserModel
    //{
    //    public int Id { get; set; }
    //    public string Md5Password { get; set; }
    //}
}

