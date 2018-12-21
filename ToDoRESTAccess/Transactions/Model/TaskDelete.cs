// ALLOWOVERWRITE-0F84F0308F50B382552FA0283E687BAC

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace Database.Transactions.Model
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