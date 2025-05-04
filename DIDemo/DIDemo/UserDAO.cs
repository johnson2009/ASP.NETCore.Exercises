using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    class UserDAO: IUserDAO
    {
        private readonly IDbConnection conn;
        public UserDAO(IDbConnection conn)
        {
            this.conn = conn;
        }

        public User? GetByUserName(string userName)
        {
            using var dt = SqlHelper.ExecuteQuery(conn, $"select * from user where user_name={userName}");
            if(dt.Rows.Count <= 0) return null;
            DataRow row = dt.Rows[0];
            int id = (int)row["Id"];
            string uName = (string)row["user_name"];
            string password = (string)row["password"];
            return new User(id, uName, password);
        }
    }
}
