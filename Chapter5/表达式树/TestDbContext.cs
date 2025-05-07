
using Microsoft.EntityFrameworkCore;

namespace 表达式树;

public class TestDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connStr = "Server=jx.sunh.fun;Port=3306;Database=demo;Username=root;Password=Amanda2007";
        optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        optionsBuilder.LogTo(msg => {
            if(msg.Contains("CommandExecuted"))
            {
                Console.WriteLine(msg);
            }
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
