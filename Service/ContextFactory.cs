using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    class ContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext dbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL("server=localhost;database=Cg2Lab;user=cg2lab;password=cg2lab;SslMode=none");
            return new ApplicationDbContext(optionsBuilder.Options); 
        }
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL("server=localhost;database=Cg2Lab;user=cg2lab;password=cg2lab;SslMode=none");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
        
    }
}
