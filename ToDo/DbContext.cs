// ALLOWOVERWRITE-51B08CFD3C06FE15436FAC1780E2CB0C
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace ToDo.Database
{
    public partial class ToDoDbContext : DbContext
    {
    
        public DbSet<User> Users { get; set; } 
        public DbSet<Task> Tasks { get; set; } 
     
	
	


     }
 }