using BookEFCore;
using Microsoft.EntityFrameworkCore;
using Jx.Common.DI;
using System.Reflection;
using Jx.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddAllDbContexts(optionBuilder =>
{
    string connStr = builder.Configuration.GetConnectionString("Default");
    optionBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
}, AppDomain.CurrentDomain.GetSolutionAssemblies());

builder.Services.AddScoped<IMemoryCacheHelper, MemoryCacheHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();