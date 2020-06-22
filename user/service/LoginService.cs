using Edith.mapper;
using Edith.user;
using Edith.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edith.service
{
    class LoginService
    {

        public static Boolean checkUserName(String userName)
        {
            if (userName.Length < 4 || userName.Length > 30)
            {
                return false;
            }

            return true;
        }

        public static Boolean checkUserNameUnique(String usernName)
        {
            if (LoginMapper.checkUserNameUnique(usernName) == 0)
            {
                return true;
            }

            return false;
        }

        public static Boolean checkPassword(String password)
        {
            if (password.Length < 6 || password.Length > 30)
            {
                return false;
            }

            return true;
        }

        public static String genPassword(User user)
        {
            String res = MD5Util.toMD5(user.userName + user.password + user.salt);

            return res;
        }

        public static String genPassword(String userName, String password, String salt)
        {
            String res = MD5Util.toMD5(userName + password + salt);

            return res;
        }

        internal static int insertUser(User user)
        {
            user.roleId = 1;
            int res = LoginMapper.insertUser(user);

            return res;
        }

        internal static Boolean validation(string userName, string password)
        {
            User user = LoginMapper.selectUserByUserName(userName);

            if (user == null)
            {
                return false;
            }

            String token = genPassword(userName, password, user.salt);

            if (token == user.password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
