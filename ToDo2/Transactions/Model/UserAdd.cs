// ALLOWOVERWRITE-F416B27FA36DE80C29072E163E86DFC6

using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Database;


namespace ToDo.Transactions.Model
{
    public class UserAdd
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



