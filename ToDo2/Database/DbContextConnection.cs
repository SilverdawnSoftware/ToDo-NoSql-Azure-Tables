// ALLOWOVERWRITE-594C428E4B12C7802EAA89FBB8E1470A
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDo.Database;

namespace ToDo.Database
{
    public partial class ToDoDbContext : DbContext
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