

//插入数据
using 一对多关系;
using Microsoft.EntityFrameworkCore;

/*
 * Article a1 = new Article();
a1.Title = "C# 8.0 新特性";
a1.Content = "C# 8.0 新特性包括可空引用类型、异步流、范围和索引等。";
Comment c1 = new Comment() { Message = "支持" };
Comment c2 = new Comment() { Message = "不支持" };
Comment c3 = new Comment() { Message = "不支持" };
a1.Comments.Add(c1);
a1.Comments.Add(c2);
a1.Comments.Add(c3);
using TestDbContext ctx = new TestDbContext();
ctx.Articles.Add(a1);
await  ctx.SaveChangesAsync();
Console.WriteLine("数据插入成功");
*/

//关联查询
using TestDbContext ctx =  new TestDbContext();
Article a = ctx.Articles.Include(a => a.Comments).Single(a => a.Id == 1);

Console.WriteLine($"文章标题：{a.Title}");
foreach(Comment c in a.Comments)
{
    Console.WriteLine($"评论ID: {c.Id}, 评论内容：{c.Message}");
}