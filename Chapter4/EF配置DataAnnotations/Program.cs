
using EF配置DataAnnotations;

using TestDbContext ctx = new TestDbContext();

Console.WriteLine("******1******");
Author a1 = new Author() { Name = "杨中科" };
Console.WriteLine($"Add前, ID={a1.Id}, Name={a1.Name}");
ctx.Authors.Add( a1 );
Console.WriteLine($"Add后, ID={a1.Id}, Name={a1.Name}");
await ctx.SaveChangesAsync();
Console.WriteLine($"保存后, ID={a1.Id}, Name={a1.Name}");

Console.WriteLine("****** 2 ******");
Author a2 = new Author() { Name = "小白" };
a2.Id = Guid.NewGuid();
Console.WriteLine($"Add前, ID={a2.Id}, Name={a2.Name}");
ctx.Authors.Add(a2);
Console.WriteLine($"Add后, ID={a2.Id}, Name={a2.Name}");
await ctx.SaveChangesAsync();
Console.WriteLine($"保存后, ID={a2.Id}, Name={a2.Name}");

