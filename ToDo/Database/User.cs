// ALLOWOVERWRITE-FA349C232DC89345C84E4A6BA1821546

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
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string HomeNumber  { get; set; }     	
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string WorkNumber  { get; set; }     	
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string AddressLine1  { get; set; }     	
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string AddressLine2  { get; set; }     	
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string City  { get; set; }     	
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string Postcode  { get; set; }     	
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string Country  { get; set; }     	
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string Company  { get; set; }     	
	    		
	    		/// <summary>  </summary>	 
	    		
	    		public string Department  { get; set; }     	
    	
    	
    	
    	
    	/// <summary>
        /// List of Tasks
        /// </summary>	
    	public virtual List<Task> Tasks { get; set; } 
    	
    	
    	
    	
    }
    
    
}



























