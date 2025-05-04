using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddEnvironmentVariables("PROCESSOR_");
IConfigurationRoot config = configBuilder.Build();
string name = config["LEVEL"];
Console.WriteLine($"Name: {name}");