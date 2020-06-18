using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        //嘗試建立mirgration檔案  ref:https://hackmd.io/8jxyByrZTJ-xQ19-LuT53A?view
        //dotnet ef migrations add InitalCreate 
        //更新資料庫
        //dotnet ef database update

        public ApplicationDbContext db;
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();            
            optionsBuilder.UseMySQL("server=localhost;database=try;user=cg2lab;password=cg2lab;SslMode=none");
            db= new ApplicationDbContext(optionsBuilder.Options); 
            return new ApplicationDbContext(optionsBuilder.Options);
        }
        
    }
}
