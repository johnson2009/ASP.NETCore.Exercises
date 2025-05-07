using 悲观并发控制;

using Microsoft.EntityFrameworkCore;
/* 
using var ctx = new MyDbContext();

House house = new House()
{
    Name = "房子1",
    Owner = null
};
ctx.Houses.Add(house);
await ctx.SaveChangesAsync(); */

Console.WriteLine("请输入你的名字：");
string name = Console.ReadLine() ?? "无名氏";

using MyDbContext ctx = new MyDbContext();
using var tx = await ctx.Database.BeginTransactionAsync();

Console.WriteLine("准备Select " + DateTime.Now.TimeOfDay);
var h1 = await ctx.Houses.FromSqlInterpolated($"select * from T_Houses where Id = 1 for update").SingleAsync();
Console.WriteLine("完成Select " + DateTime.Now.TimeOfDay);

if(string.IsNullOrEmpty(h1.Owner))
{
    await Task.Delay(5000);
    h1.Owner = name;
    await ctx.SaveChangesAsync();
    Console.WriteLine("抢到收了");
}
else
{
    if(h1.Owner == name)
        Console.WriteLine("这个房子已经是你的了，不用抢了");
    else
        Console.WriteLine($"这个房子已经被{h1.Owner}抢走了");
}
await tx.CommitAsync();
Console.ReadKey();