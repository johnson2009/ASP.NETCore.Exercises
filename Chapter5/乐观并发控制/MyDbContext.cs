using Microsoft.EntityFrameworkCore;

namespace 乐观并发控制;

public class MyDbContext:DbContext
{
    public DbSet<House> Houses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connStr = "Server=jx.sunh.fun;Port=3306;Database=demo;Username=root;Password=Amanda2007";
        optionsBuilder.UseMySql(connStr, new MySqlServerVersion(new Version(9, 2, 0)));
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