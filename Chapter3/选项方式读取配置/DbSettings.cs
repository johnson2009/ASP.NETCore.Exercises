using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 选项方式读取配置
{
    public class DbSettings
    {
        public string DbType { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
    }
}
