// ALLOWOVERWRITE-C3B068C87CF7C6EAA53072CDBE8AF2F2

using System;
using System.Collections.Generic;
using System.Linq;



namespace ToDo.Database.Views.Model
{

    public class TaskView
    {
    
   
    
	    	
	    	
	    	/// <summary>
            /// The data the task was completed
            /// </summary>
	    	public DateTime  CompletedDate  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
	    	public DateTime  DueDate  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The name of the task to be done
            /// </summary>
	    	public string  Name  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// When the task was started
            /// </summary>
	    	public DateTime  StartedDate  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The status of the task e.g, Inprogress, Completed
            /// </summary>
	    	public int  Status  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// Unique identifier for a task
            /// </summary>
	    	public int  TaskId  { get; set; } 	    	
    						  
					   /// <summary>
                      /// Reference of PrimaryKey for User
                      /// </summary>
					  public  int UserUserId { get; set; }   
    	
    	
    	
    	public static explicit operator TaskView(Database.Task item)
    	{
    	 var result=new TaskView();
    	 
	    	result.CompletedDate = item.CompletedDate;     
	    	result.DueDate = item.DueDate;     
	    	result.Name = item.Name;     
	    	result.StartedDate = item.StartedDate;     
	    	result.Status = item.Status;     
	    	result.TaskId = item.TaskId;     
    	
if (item.User != null) 
			    			{   
		    		   result.UserUserId=item.User.UserId;
		    		   } 
    	
    	
    	return result;
     }   
   
    }
}


