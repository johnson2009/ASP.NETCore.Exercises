using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    interface IUserBiz
    {
        public bool CheckLogin(string userName, string password);
    }
}
