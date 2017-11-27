// ALLOWOVERWRITE-A590553EB9AFCF6CB5DE345B1D691CD3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace ToDo.Transactions.Model
{
	[DataContract]
    public class TaskDelete
    {
    	
    	
    	/// <summary>
        /// Unique identifier for a task
        /// </summary>
		 [DataMember(Name = "taskId")]         
    	public int  TaskId  { get; set; } 
    	
    }
}