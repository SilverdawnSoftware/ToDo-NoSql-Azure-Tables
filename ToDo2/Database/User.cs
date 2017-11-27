// ALLOWOVERWRITE-9755AF067302D758D242B1E34727FDE7

using System;
using System.Collections.Generic;
using System.Linq;



namespace ToDo.Database
{
    public class User
    {
	    		
	    		/// <summary> Unique identifier for user </summary>	 
	    		
	    		public int UserId  { get; set; }     	
	    		
	    		/// <summary> The title of the user e.g. Mrs,Mr </summary>	 
	    		
	    		public string Title  { get; set; }     	
	    		
	    		/// <summary> The users first name </summary>	 
	    		
	    		public string FirstName  { get; set; }     	
	    		
	    		/// <summary> The users surname </summary>	 
	    		
	    		public string Surname  { get; set; }     	
	    		
	    		/// <summary> The users email address </summary>	 
	    		
	    		public string Email  { get; set; }     	
	    		
	    		/// <summary> The users mobile number </summary>	 
	    		
	    		public string MobileNumber  { get; set; }     	
    	
    	
    	
    	
    	/// <summary>
        /// List of Tasks
        /// </summary>	
    	public virtual List<Task> Tasks { get; set; } 
    	
    	
    	
    	
    }
    
    
}



























