// ALLOWOVERWRITE-B4ADAF9B4631DDF0365DF7879B271D7D

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace Database.Views.Model
{

	[DataContract]
    public class TaskView
    {
    
   
    
	    	
	    	
	    	/// <summary>
            /// The data the task was completed
            /// </summary>
			 [DataMember(Name = "completedDate")]            
	    	public DateTime  CompletedDate  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// 
            /// </summary>
			 [DataMember(Name = "dueDate")]            
	    	public DateTime  DueDate  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The name of the task to be done
            /// </summary>
			 [DataMember(Name = "name")]            
	    	public string  Name  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// When the task was started
            /// </summary>
			 [DataMember(Name = "startedDate")]            
	    	public DateTime  StartedDate  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// The status of the task e.g, Inprogress, Completed
            /// </summary>
			 [DataMember(Name = "status")]            
	    	public int  Status  { get; set; } 	    	
	    	
	    	
	    	/// <summary>
            /// Unique identifier for a task
            /// </summary>
			 [DataMember(Name = "taskId")]            
	    	public int  TaskId  { get; set; } 	    	
    						  
					   /// <summary>
                      /// Reference of PrimaryKey for User
                      /// </summary>
                      [DataMember(Name = "userUserId")]
					  public  int UserUserId { get; set; }   
    	
    	
    	
    	
   
    }
}


