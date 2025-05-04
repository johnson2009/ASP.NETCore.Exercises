using DIDemo;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;

ServiceCollection services = new ServiceCollection();
services.AddScoped<IDbConnection>(sp =>
{
    string connStr = "Server=jx.sunh.fun;Port=3306;Database=chapter05;Username=root;Password=Amanda2007";
    var conn = new MySqlConnection(connStr);
    conn.Open();
    return conn;
});

services.AddScoped<IUserDAO, UserDAO>();
services.AddScoped<IUserBiz, UserBiz>();
using(ServiceProvider sp = services.BuildServiceProvider())
{
    var userBiz = sp.GetRequiredService<IUserBiz>();
    bool b = userBiz.CheckLogin("科比", "123456");
    Console.WriteLine(b);
}