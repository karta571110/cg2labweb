using cg2labweb.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Service
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options)
       : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
