// ALLOWOVERWRITE-BC81DE5A4707B8C64D6077AE97CD1D06

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace ToDo.Transactions.Model
{
	[DataContract]
    public class TaskUpdate
    {
	    		
	    		/// <summary>
                /// The data the task was completed
                /// </summary>
				 [DataMember(Name = "completedDate")]                 
	    		public DateTime CompletedDate  { get; set; } 
	    		
	    		/// <summary>
                /// When the task needs to be completed by
                /// </summary>
				 [DataMember(Name = "dueDate")]                 
	    		public DateTime DueDate  { get; set; } 
	    		
	    		/// <summary>
                /// The name of the task to be done
                /// </summary>
				 [DataMember(Name = "name")]                 
	    		public string Name  { get; set; } 
	    		
	    		/// <summary>
                /// When the task was started
                /// </summary>
				 [DataMember(Name = "startedDate")]                 
	    		public DateTime StartedDate  { get; set; } 
	    		
	    		/// <summary>
                /// The status of the task e.g, Inprogress, Completed
                /// </summary>
				 [DataMember(Name = "status")]                 
	    		public int Status  { get; set; } 
	    		
	    		/// <summary>
                /// Unique identifier for a task
                /// </summary>
				 [DataMember(Name = "taskId")]                 
	    		public int TaskId  { get; set; } 
    	
    }
}

