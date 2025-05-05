using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace 一对多关系
{
    public class Article
    {
        public long Id {  get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
