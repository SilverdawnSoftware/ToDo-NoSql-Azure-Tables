// ALLOWOVERWRITE-86C4BF48F7D023E07C6857EE79184BF1

using System;
using System.Collections.Generic;
using System.Linq;



namespace ToDo.Database
{
    public class Task
    {
	    		
	    		/// <summary> Unique identifier for a task </summary>	 
	    		
	    		public int TaskId  { get; set; }     	
	    		
	    		/// <summary> The name of the task to be done </summary>	 
	    		
	    		public string Name  { get; set; }     	
	    		
	    		/// <summary> When the task needs to be completed by </summary>	 
	    		
	    		public DateTime DueDate  { get; set; }     	
	    		
	    		/// <summary> When the task was started </summary>	 
	    		
	    		public DateTime StartedDate  { get; set; }     	
	    		
	    		/// <summary> The status of the task e.g, Inprogress, Completed </summary>	 
	    		
	    		public int Status  { get; set; }     	
	    		
	    		/// <summary> The data the task was completed </summary>	 
	    		
	    		public DateTime CompletedDate  { get; set; }     	
    	
    	
    	
    	/// <summary>
        /// Reference to  User
        /// </summary>	
    	public virtual User User { get; set; } 
    	
    	
    	
    	
    	
    }
    
    
}



























