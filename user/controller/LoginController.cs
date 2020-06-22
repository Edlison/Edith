using Edith.result;
using Edith.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edith.user;

namespace Edith.controller
{
    class LoginController
    {
        public SystemResult SignUp(String userName, String password)
        {
            if (!LoginService.checkUserName(userName))
            {
                return new SystemResult("username length must between 4 to 30 !", 101);
            }
            if (!LoginService.checkUserNameUnique(userName))
            {
                return new SystemResult("username already exist !", 102);
            }
            if (!LoginService.checkPassword(password))
            {
                return new SystemResult("password length must between 6 to 30 !", 103);
            }

            User user = new User();

            user.userName = userName;
            user.password = password;
            user.randomSalt();
            user.password = LoginService.genPassword(user);

            LoginService.insertUser(user);
            
            return new SystemResult("Sign up success", 0);
        }

        public SystemResult SignIn(String userName, String password)
        {
            if (!LoginService.validation(userName, password))
            {
                return new SystemResult("sign in fail !", 201);
            }

            return new SystemResult("sign in success !", 0);
        }
    }
}
