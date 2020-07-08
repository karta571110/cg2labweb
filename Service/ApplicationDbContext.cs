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
        public DbSet<UndergraduateStudentsWork> undergraduateStudentsWorks { get; set; }
        public DbSet<HankPageJournalPaper> HankPageJournalPapers { get; set; }
        public DbSet<HankPageSeminarPaper> HankPageSeminarPapers { get; set; }
        public DbSet<HankPageProject> hankPageProjects { get; set; }
        public DbSet<HankPageHonor> hankPageHonors { get; set; }
        public DbSet<StudentData> StudentData { get; set; }
        public DbSet<IndustryResearch> industryResearches { get; set; }
    }

}
