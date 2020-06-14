using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    class ContextFactory
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseMySQL("server=localhost;database=Cg2Lab;user=cg2lab;password=cg2lab;SslMode=none");
            return new Context(optionsBuilder.Options);
        }
    }
}
