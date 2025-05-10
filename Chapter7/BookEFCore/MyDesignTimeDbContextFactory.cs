using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEFCore
{
    public class MyDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            string connStr = Environment.GetEnvironmentVariable("ConnectionStrings:BooksEFCore");
            optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
