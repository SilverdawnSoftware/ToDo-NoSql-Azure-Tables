// ALLOWOVERWRITE-F5936D9A243816DB17BA4803247337CD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDo.Database;

namespace ToDo.Database
{
    public partial class  : DbContext
    {
    
        public DbSet<User> Users { get; set; } 
        public DbSet<Task> Tasks { get; set; } 
     

	


     }
 }