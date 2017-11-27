// ALLOWOVERWRITE-D86145FE7DA7428A8E06B4C89B66F06F

using System;
using System.Collections.Generic;
using System.Linq;



namespace ToDo.Transactions.Model
{
    public class TaskUpdate
    {
	    		
	    		/// <summary>
                /// The data the task was completed
                /// </summary>	 
	    		public DateTime CompletedDate  { get; set; } 
	    		
	    		/// <summary>
                /// When the task needs to be completed by
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
    	
    }
}

