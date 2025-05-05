
using Microsoft.EntityFrameworkCore;
using 一对一关系;

using TestDbContext ctx = new TestDbContext();
Order order = new Order();
order.Address = "上海市浦东新区";
order.Name = "充电器";
Delivery delivery = new Delivery();
delivery.CompanyName = "顺丰快递";
delivery.Number = "SF123456789";
delivery.Order = order;

ctx.Deliveries.Add(delivery);
await ctx.SaveChangesAsync();

Order order1 = await ctx.Orders.Include(o => o.Delivery).FirstAsync(o => o.Name.Contains("充电器"));
Console.WriteLine($"订单ID: {order1.Id}, 订单地址: {order1.Address}, 快递公司: {order1.Delivery.CompanyName}, 快递单号: {order1.Delivery.Number}");