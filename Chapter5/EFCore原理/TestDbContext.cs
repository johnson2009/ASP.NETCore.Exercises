using Microsoft.EntityFrameworkCore;

namespace EFCore原理;

public class TestDbContext:DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
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
