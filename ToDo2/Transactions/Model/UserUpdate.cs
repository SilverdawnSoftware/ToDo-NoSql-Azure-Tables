// ALLOWOVERWRITE-384D47D5712725741C1D33C07314857D

using System;
using System.Collections.Generic;
using System.Linq;



namespace ToDo.Transactions.Model
{
    public class UserUpdate
    {
	    		
	    		/// <summary>
                /// The users email address
                /// </summary>	 
	    		public string Email  { get; set; } 
	    		
	    		/// <summary>
                /// The users first name
                /// </summary>	 
	    		public string FirstName  { get; set; } 
	    		
	    		/// <summary>
                /// The users mobile number
                /// </summary>	 
	    		public string MobileNumber  { get; set; } 
	    		
	    		/// <summary>
                /// The users surname
                /// </summary>	 
	    		public string Surname  { get; set; } 
	    		
	    		/// <summary>
                /// The title of the user e.g. Mrs,Mr
                /// </summary>	 
	    		public string Title  { get; set; } 
	    		
	    		/// <summary>
                /// Unique identifier for user
                /// </summary>	 
	    		public int UserId  { get; set; } 
    	
    }
}

