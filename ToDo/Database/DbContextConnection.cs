// ALLOWOVERWRITE-D063AD40E8EE81F98916EB2F9235B5D9
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDo.Database;

namespace ToDo.Database
{
    public partial class  : DbContext
    {
    
   
	// Delete if not required	
	 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: true)
            //    .Build();
            //var conn = configuration["ConnectionStrings:ToDoConnection"];

            //optionsBuilder.UseSqlServer(conn);

           optionsBuilder.UseSqlServer(@"Server=.;Database=ToDo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }	


     }
 }