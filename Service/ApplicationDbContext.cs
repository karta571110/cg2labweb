using infra.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace Service
{
    public class ApplicationDbContext:DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        
        public DbSet<Member> Members { get; set; }
        public DbSet<MasterPaper> MasterPapers { get; set; }
   
    }

}
