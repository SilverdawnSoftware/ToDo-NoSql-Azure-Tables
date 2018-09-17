// ALLOWOVERWRITE-0C4C89CC18BFCC5EE88ADF24483E03E7
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDo.Database;

namespace ToDo.Database
{
    public partial class ToDoDbContext : DbContext
    {
    
        public DbSet<User> Users { get; set; } 
        public DbSet<Task> Tasks { get; set; } 
     
	
	


     }
 }