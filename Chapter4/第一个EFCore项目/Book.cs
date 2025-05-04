using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第一个EFCore项目
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime PubTime { get; set; }
        public double Price { get; set; }
        public string AuthorName { get; set; }

        public DateTime InsertDateTime { get; set; } = DateTime.Now;

    }
}
