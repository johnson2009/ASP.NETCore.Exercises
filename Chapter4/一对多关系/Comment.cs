﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 一对多关系
{
    public class Comment
    {
        public long Id { get; set; }
        public Article Article { get; set; }
        public long ArticleId {get; set;}
        public string Message { get; set; } = null!;
    }
}
