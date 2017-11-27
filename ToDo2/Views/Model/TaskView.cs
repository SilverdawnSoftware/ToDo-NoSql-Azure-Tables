// ALLOWOVERWRITE-32091EDE62D983DB4BF5355B815946EE

using System;
using System.Collections.Generic;
using System.Linq;



namespace ToDo.Views.Model
{

    public class TaskView
    {
    
   
    
	    	
	    	
	    	/// <summary>
            /// The data the task was completed
            /// </summary>	
	    	public DateTime  CompletedDate  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// When the task needs to be completed by
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
					  
					  /// <summary>
                      /// Reference to  User Email Property
                      /// </summary>	
					  public string UserEmail { get; set; }   
    	
    	
    	
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
		    		if (item.User != null) 
			    			{   	
		    			result.UserEmail=item.User.Email; 
		    			} 
    	
    	
    	return result;
     }   
   
    }
}


