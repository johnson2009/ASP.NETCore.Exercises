using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using 选项方式读取配置;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
IConfigurationRoot config = configBuilder.Build();

ServiceCollection services = new ServiceCollection();
services.AddOptions()
    .Configure<DbSettings>(e => config.GetSection("DB").Bind(e))
    .Configure<SmtpSettings>(e => config.GetSection("Smtp").Bind(e));

services.AddTransient<Demo>();

using (var sp = services.BuildServiceProvider())
{
    while (true)
    {
        using (var scope = sp.CreateScope())
        {
            var spScope = scope.ServiceProvider;
            var demo = spScope.GetRequiredService<Demo>();
            demo.Test();
        }
        Console.WriteLine("可以修改配置了");
        Console.ReadLine();
    }
}