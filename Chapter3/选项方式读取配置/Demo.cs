using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace 选项方式读取配置
{
    class Demo
    {
        private readonly IOptionsSnapshot<DbSettings> optDbSettings;
        private readonly IOptionsSnapshot<SmtpSettings> optSmtpSettings;
        public Demo(IOptionsSnapshot<DbSettings> optDbSettings, IOptionsSnapshot<SmtpSettings> optSmtpSettings)
        {
            this.optDbSettings = optDbSettings;
            this.optSmtpSettings = optSmtpSettings;
        }

        public void Test()
        {
            var db = optDbSettings.Value;
            Console.WriteLine($"数据库：DbType: {db.DbType}, {db.ConnectionString}");
            var smtp = optSmtpSettings.Value;
            Console.WriteLine($"smtp: {smtp.Server}, {smtp.UserName}, {smtp.Password}");
        }

    }
}
