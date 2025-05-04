using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    interface IUserDAO
    {
        User? GetByUserName(string userName);
    }
}
