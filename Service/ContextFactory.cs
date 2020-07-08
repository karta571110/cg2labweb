using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using infra.Models;

namespace Service
{
   public class ContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext dbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL("server=192.168.1.68;database=cg2lab;user=root;password=mylovelife27;SslMode=none");
            return new ApplicationDbContext(optionsBuilder.Options); 
        }
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL("server=192.168.1.68;database=Cg2Lab;user=cg2lab;password=cg2lab;SslMode=none");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
        
    }
}
