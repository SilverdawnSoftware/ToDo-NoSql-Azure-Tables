// ALLOWOVERWRITE-BA917D98DFD2057AFCBF0F581C32081F

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
    public partial class TaskViews
    {
    
    
    	public async Task<List<TaskView>> GetAll()
        {
        	try
            {
	            using (var db = new ())
	            {
	                var temp = await db.Tasks.ToListAsync();
	                return temp.ConvertAll(user => (TaskView) user);
	            }
            }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;             
            }            
        }
    
    
    	
    	public async Task<TaskView> Get(int taskId)
    	{
    		
    		try
            {
	    		using (var db = new ())
	            {
	            	if (await db.Tasks.AnyAsync(w=>w.TaskId==taskId))
	                {
	                	return (TaskView)await db.Tasks.FirstAsync(w=>w.TaskId==taskId);
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
    	
    	
		
		public async Task<List<TaskView>> GetTasksForUser(int userId)
    	{
    		try
            {
    	
	    		using (var db = new ())
	            {
	            	var result= await db.Tasks.Where(w=>w.User.UserId ==userId).ToListAsync();
	            	return result.ConvertAll(user => (TaskView) user);
	               
	            }
	        }
            catch (Exception e)
            {
            	LogFactory.GetLogger().Log(LogLevel.Error,e);
                return null;
              
            }    
	            
    	}
    	
    	
    }
}

