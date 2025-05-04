using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    class UserBiz:IUserBiz
    {
        private readonly IUserDAO userDAO;
        public UserBiz(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        public bool CheckLogin(string userName, string password)
        {
            var user = userDAO.GetByUserName(userName);
            if (user == null) return false;
            return user.Password == password;
        }
    }
}
