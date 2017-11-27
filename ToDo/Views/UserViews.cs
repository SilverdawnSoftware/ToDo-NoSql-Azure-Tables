// ALLOWOVERWRITE-DCAFF080233AD64E151218047C912C7E

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Silverdawn.Exceptions;
using ToDo.Views.Model;
using ToDo.Database;

namespace ToDo.Views
{
    public partial class UserViews
    {
    
    
    	public async Task<List<UserView>> GetAll()
        {
        	try
            {
	            using (var db = new ToDoDbContext())
	            {
	                var temp = await db.Users.ToListAsync();
	                return temp.ConvertAll(user => (UserView) user);
	            }
            }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;             
            }            
        }
    
    
    	
    	public async Task<UserView> Get(int userId)
    	{
    		
    		try
            {
	    		using (var db = new ToDoDbContext())
	            {
	            	if (await db.Users.AnyAsync(w=>w.UserId==userId))
	                {
	                	return (UserView)await db.Users.FirstAsync(w=>w.UserId==userId);
	            	}
	            }	    	
	    		return null;
    		 }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;              
            }     		
    	}
    	
    	
    	
    }
}

