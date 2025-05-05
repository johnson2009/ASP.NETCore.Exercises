using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一对一关系
{
    class Delivery
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string Number { get; set; }
        public Order? Order { get; set; } // 反向导航属性
        public long OrderId { get; set; } // 外键
    }
}
