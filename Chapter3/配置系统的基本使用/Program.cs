using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: true);
IConfigurationRoot config = configBuilder.Build();

string name = config["Name"];
Console.WriteLine($"Name: {name}");
string proxyAddress = config.GetSection("proxy:address").Value;
Console.WriteLine($"Proxy Address: {proxyAddress}");