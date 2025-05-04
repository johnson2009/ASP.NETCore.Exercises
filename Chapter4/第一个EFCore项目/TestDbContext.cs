using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第一个EFCore项目
{
    public class TestDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = "Server=jx.sunh.fun;Port=3306;Database=demo;Username=root;Password=Amanda2007";
            optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
