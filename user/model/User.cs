using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edith.user
{
    class User
    {
        public String userId;
        public String userName;
        public String password;
        public String salt;
        public int roleId;

        public void randomSalt()
        {
            this.salt = "gre532";
        }
    }
}
