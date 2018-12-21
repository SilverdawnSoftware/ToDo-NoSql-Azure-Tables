// ALLOWOVERWRITE-5C6AE323B108EFA616C0BB5A659699AD

using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Database;


namespace ToDo.Database.Transactions.Model
{
    public class TaskAdd
    {
	    		
	    		 /// <summary>
                  /// The data the task was completed
                  /// </summary>	    		
	    		public DateTime CompletedDate  { get; set; } 
	    		
	    		 /// <summary>
                  /// 
                  /// </summary>	    		
	    		public DateTime DueDate  { get; set; } 
	    		
	    		 /// <summary>
                  /// The name of the task to be done
                  /// </summary>	    		
	    		public string Name  { get; set; } 
	    		
	    		 /// <summary>
                  /// When the task was started
                  /// </summary>	    		
	    		public DateTime StartedDate  { get; set; } 
	    		
	    		 /// <summary>
                  /// The status of the task e.g, Inprogress, Completed
                  /// </summary>	    		
	    		public int Status  { get; set; } 
	    		
	    		 /// <summary>
                  /// Unique identifier for a task
                  /// </summary>	    		
	    		public int TaskId  { get; set; } 
    	   	
    	
    	/// <summary>
        /// Unique identifier for user
        /// </summary>	
       
    	public int UserUserId { get; set; } 
    }    	    	
}



