using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 服务接口;

namespace 服务实现1
{
    public class CnService : IMyService
    {
        public void SayHello()
        {
            Console.WriteLine("你好，世界！");
        }
    }
}
